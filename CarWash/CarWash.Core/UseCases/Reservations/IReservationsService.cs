using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Persistence.UseCases.Reservations
{
    public interface IReservationsService
    {
        void BookReservation(Reservation reservation);
    }
}
