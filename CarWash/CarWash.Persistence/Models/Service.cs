using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Models
{
    public class Service
    {
        public Service()
        {

        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
