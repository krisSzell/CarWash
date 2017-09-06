using System;

namespace CarWash.Persistence.Models.Logging
{
    public class FullLog
    {
        public int FullLogId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserResponsible { get; set; }
        public string OperationMade { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return TimeStamp.ToString() + " - "
                + UserResponsible + " - " + OperationMade + " - " + Details;
        }
    }
}
