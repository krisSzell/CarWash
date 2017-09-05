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

        public bool BookReservation(Reservation reservation)
        {
            var hasBeenAdded = _unitOfWork.Reservations.Add(reservation);
            _unitOfWork.PersistChanges();

            return hasBeenAdded;
        }

        public IEnumerable<Reservation> GetUnconfirmed()
        {
            var unconfirmedReservations = _unitOfWork.Reservations.GetUnconfirmed();

            return unconfirmedReservations;
        }
    }
}
