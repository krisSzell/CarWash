using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.Core.Dtos
{
    public class ReservationDto
    {
        public Service Service { get; set; }
        public Date Date { get; set; }
        public string UserId { get; set; }
    }

    public class Date
    {
        public string Hour { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}