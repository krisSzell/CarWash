using Newtonsoft.Json;
using System.Collections.Generic;

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

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
