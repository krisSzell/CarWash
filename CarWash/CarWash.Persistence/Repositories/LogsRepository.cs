using CarWash.Persistence.Models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly LoggingDbContext _context;

        public LogsRepository(LoggingDbContext context)
        {
            _context = context;
        }

        public void PersistLog(FullLog log)
        {
            _context.FullLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
