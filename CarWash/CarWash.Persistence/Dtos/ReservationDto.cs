using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.Persistence.Dtos
{
    public class ReservationDto
    {
        public Service Service { get; set; }
        public Date Date { get; set; }
        public string Username { get; set; }
    }

    public class Date
    {
        public string Hour { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}