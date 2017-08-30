using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ICollection<Reservation> Reservations { get; set; }
    }
}
