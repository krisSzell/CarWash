using CarWash.Persistence.Models.Accounts;
using CarWash.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CarWash.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IReservationsRepository Reservations { get; set; }
        public IServiceRepository Services { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Reservations = new ReservationsRepository(context);
            Services = new ServiceRepository(context);
            Users = _context.Users.ToList();
        }

        public void PersistChanges()
        {
            _context.SaveChanges();
        }
    }
}
