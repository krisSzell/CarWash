using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Core.Models;
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

        public void Add(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations
                .Include(r => r.Schedule)
                .Include(r => r.Service)
                .Include(r => r.Status)
                .ToList();
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations
                .Include(r => r.Schedule)
                .Include(r => r.Service)
                .Include(r => r.Status)
                .SingleOrDefault(r => r.ReservationId == id);
        }
    }
}
