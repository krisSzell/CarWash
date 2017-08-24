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

    }
}
