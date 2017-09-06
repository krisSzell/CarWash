using CarWash.Persistence.Models;
using System.Collections.Generic;

namespace CarWash.Persistence.UseCases.Reservations
{
    public interface IReservationsService
    {
        bool BookReservation(Reservation reservation);
        IEnumerable<Reservation> GetUnconfirmed();
        IEnumerable<Reservation> GetConfirmed();
        void Confirm(int reservationId);
        void Reject(int reservationId);
    }
}
