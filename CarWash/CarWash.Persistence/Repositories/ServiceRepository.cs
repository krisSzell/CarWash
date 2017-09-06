using CarWash.Persistence.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAll()
        {
            return _context.Services.ToList();
        }
    }
}
