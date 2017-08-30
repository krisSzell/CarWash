using System;
using System.Collections.Generic;
using System.Text;

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

        public ICollection<Reservation> Reservations { get; set; }
    }
}
