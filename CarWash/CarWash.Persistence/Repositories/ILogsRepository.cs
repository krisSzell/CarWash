using CarWash.Persistence.Models.Logging;
using System.Collections.Generic;

namespace CarWash.Persistence.Repositories
{
    public interface ILogsRepository
    {
        void PersistLog(FullLog log);
        IEnumerable<FullLog> GetAll();
    }
}
