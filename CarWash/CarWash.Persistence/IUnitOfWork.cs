using CarWash.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence
{
    public interface IUnitOfWork
    {
        IReservationsRepository Reservations { get; set; }
        IServiceRepository Services { get; set; }
        void PersistChanges();
    }
}
