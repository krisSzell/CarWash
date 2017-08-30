using CarWash.Core.Dtos;
using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Core.UseCases.Reservations
{
    public interface IReservationsService
    {
        void BookReservation(Reservation reservation);
    }
}
