namespace CarWash.Persistence.Models
{
    public class WorkHour
    {
        public WorkHour(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }

        public override string ToString()
        {
            string hour = Hour.ToString();
            string minute = Minute.ToString();

            if (Hour < 10)
            {
                hour = $"0{Hour}";
            }
            if (Minute < 10)
            {
                minute = $"0{Minute}";
            }

            return $"{hour}:{minute}";
        }

        public override bool Equals(object obj)
        {
            var workHour = (WorkHour)obj;
            if (Hour == workHour.Hour && Minute == workHour.Minute)
            {
                return true;
            }
            return false;
        }
    }
}
