using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Persistence.Models;
using System.Data.Entity;

namespace CarWash.Persistence.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private ApplicationDbContext _context;

        public ReservationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Reservation reservation)
        {
            var reservations = _context.Reservations.ToList();
            if (reservations.SingleOrDefault(r => r.ReservationId == reservation.ReservationId) == null)
            {
                updateIdOfStatus(reservation);
                updateIdOfService(reservation);
                _context.Reservations.Add(reservation);

                // change state of service and status entries to prevent EF from adding them to the table (since they exist)
                _context.ChangeTracker.Entries<Service>().ToList().ForEach(p => p.State = EntityState.Unchanged);
                _context.ChangeTracker.Entries<Status>().ToList().ForEach(p => p.State = EntityState.Unchanged);
                return true;
            }
            return false;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations
                .Include(r => r.Schedule)
                .Include(r => r.Service)
                .Include(r => r.Status)
                .ToList();
        }

        public IEnumerable<Reservation> GetUnconfirmed()
        {
            return _context.Reservations
                .Include(r => r.Schedule)
                .Include(r => r.Service)
                .Include(r => r.Status)
                .Where(r => r.Status.IsAccepted == false)
                .ToList();
        }

        public void Confirm(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            var currentStatus = _context.Statuses
                .FirstOrDefault(s => s.Id == (int)StatusType.NotAccepted);
            var updatedStatus = _context.Statuses
                .FirstOrDefault(s => s.Id == (int)StatusType.Accepted);
            currentStatus.Reservations.Remove(reservation);
            if (updatedStatus.Reservations == null)
            {
                updatedStatus.Reservations = new List<Reservation>();
            }
            updatedStatus.Reservations.Add(reservation);
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations
                .Include(r => r.Schedule)
                .Include(r => r.Service)
                .Include(r => r.Status)
                .SingleOrDefault(r => r.ReservationId == id);
        }

        private void updateIdOfStatus(Reservation reservation)
        {
            var statuses = _context.Statuses.ToList();
            reservation.Status = statuses.SingleOrDefault(s =>
                s.IsAccepted == reservation.Status.IsAccepted &&
                s.IsArchived == reservation.Status.IsArchived);
        }
        private void updateIdOfService(Reservation reservation)
        {
            var services = _context.Services.ToList();
            reservation.Service = services.SingleOrDefault(s =>
                s.ServiceId == reservation.Service.ServiceId);
        }
    }
}
