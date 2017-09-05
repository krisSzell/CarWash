using CarWash.Core.UseCases.Logging;
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
        IEnumerable<Reservation> GetConfirmed();
        void Confirm(int reservationId);
        void Reject(int reservationId);
    }
}
