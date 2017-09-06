using CarWash.Persistence.Models.Logging;
using System.Data.Entity;

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
