using CarWash.Persistence.Models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public interface ILogsRepository
    {
        void PersistLog(FullLog log);
    }
}
