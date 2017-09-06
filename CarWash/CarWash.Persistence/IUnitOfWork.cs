using CarWash.Persistence.Models.Accounts;
using CarWash.Persistence.Repositories;
using System.Collections.Generic;

namespace CarWash.Persistence
{
    public interface IUnitOfWork
    {
        IReservationsRepository Reservations { get; set; }
        IServiceRepository Services { get; set; }
        IEnumerable<ApplicationUser> Users { get; set; }
        void PersistChanges();
    }
}
