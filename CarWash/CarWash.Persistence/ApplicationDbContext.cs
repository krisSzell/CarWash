using CarWash.Persistence.Models;
using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarWash.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
