using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.UseCases.Reservations
{
    public interface IReservationsService
    {
        bool BookReservation(Reservation reservation);
        IEnumerable<Reservation> GetUnconfirmed();
        void Confirm(int reservationId);
    }
}
