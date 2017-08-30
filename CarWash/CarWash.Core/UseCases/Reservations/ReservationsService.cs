using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;

namespace CarWash.Persistence.UseCases.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private IUnitOfWork _unitOfWork;
//        private IReservationsRepository _repository;

        public ReservationsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BookReservation(Reservation reservation)
        {
            var reservations = _unitOfWork.Reservations.GetAll();
            reservations.SingleOrDefault(r => r.ReservationId == reservation.ReservationId);
        }
    }
}
