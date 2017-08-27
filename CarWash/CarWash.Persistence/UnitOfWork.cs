using CarWash.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IReservationsRepository Reservations { get; set; }
        public IServiceRepository Services { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Reservations = new ReservationsRepository(context);
            Services = new ServiceRepository(context);
        }

        public void PersistChanges()
        {
            _context.SaveChanges();
        }
    }
}
