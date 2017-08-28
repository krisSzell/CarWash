using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.Models
{
    public class WorkDayDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public List<string> WorkHours { get; set; }
        public bool IsSelected { get; set; }
    }
}