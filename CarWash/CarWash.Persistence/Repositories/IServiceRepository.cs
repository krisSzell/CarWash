using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public interface IServiceRepository
    {
        List<Service> GetAll();
    }
}
