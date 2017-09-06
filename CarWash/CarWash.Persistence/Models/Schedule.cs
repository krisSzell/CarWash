using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CarWash.Persistence.Models
{
    public class Schedule
    {
        public Schedule()
        {

        }

        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAvailable { get; set; }

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
