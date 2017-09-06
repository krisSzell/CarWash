using System.Collections.Generic;

namespace CarWash.Persistence.Dtos
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