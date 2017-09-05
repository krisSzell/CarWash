using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
