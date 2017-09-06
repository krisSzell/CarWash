using CarWash.Persistence.Models.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CarWash.Persistence.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly LoggingDbContext _context;

        public LogsRepository(LoggingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FullLog> GetAll()
        {
            return _context.FullLogs.ToList();
        }

        public void PersistLog(FullLog log)
        {
            _context.FullLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
