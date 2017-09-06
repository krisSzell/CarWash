using CarWash.Persistence.Models;

namespace CarWash.Persistence.Dtos
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public Service Service { get; set; }
        public Status Status { get; set; }
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