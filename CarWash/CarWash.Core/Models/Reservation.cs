using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ReservationDateId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }

        public virtual Service Service { get; set; }
    }
}
