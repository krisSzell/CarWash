using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Core.Models
{
    public class Reservation
    {
        public Reservation()
        {

        }

        public int ReservationId { get; set; }

        public Service Service { get; set; }
        public Status Status { get; set; }
        public Schedule Schedule { get; set; }
        public string UserId { get; set; }
    }
}
