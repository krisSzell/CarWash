using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Models.Logging
{
    public class FullLog
    {
        public int FullLogId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserResponsible { get; set; }
        public string OperationMade { get; set; }
    }
}
