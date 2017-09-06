using CarWash.Persistence.Models;
using System.Collections.Generic;

namespace CarWash.Persistence.Repositories
{
    public interface IReservationsRepository
    {
        bool Add(Reservation reservation);
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetUnconfirmed();
        IEnumerable<Reservation> GetConfirmed();
        Reservation GetById(int id);
        void Confirm(int reservationId);
        void Reject(int reservationId);
    }
}
