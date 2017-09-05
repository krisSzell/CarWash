using CarWash.Persistence.Models.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext()
            : base("DefaultConnection")
        {
        }

        public static LoggingDbContext Create()
        {
            return new LoggingDbContext();
        }

        public DbSet<FullLog> FullLogs { get; set; }
    }
}
