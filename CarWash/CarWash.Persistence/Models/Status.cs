using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarWash.Persistence.Models
{
    public class Status
    {
        public Status()
        {

        }

        public int Id { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsArchived { get; set; }

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
