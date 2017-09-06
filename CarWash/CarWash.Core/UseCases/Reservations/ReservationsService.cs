using CarWash.Persistence.Models;
using System.Collections.Generic;

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

        public IEnumerable<Reservation> GetConfirmed()
        {
            var confirmedReservations = _unitOfWork.Reservations.GetConfirmed();

            return confirmedReservations;
        }

        public void Confirm(int reservationId)
        {
            _unitOfWork.Reservations.Confirm(reservationId);
            _unitOfWork.PersistChanges();
        }

        public void Reject(int reservationId)
        {
            _unitOfWork.Reservations.Reject(reservationId);
            _unitOfWork.PersistChanges();
        }
    }
}
