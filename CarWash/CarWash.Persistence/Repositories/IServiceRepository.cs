using CarWash.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
    }
}
