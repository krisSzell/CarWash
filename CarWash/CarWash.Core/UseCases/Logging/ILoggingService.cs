using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.UseCases.Logging
{
    public interface ILoggingService
    {
        void AddUser(string fullname);
        void AddOperationMade(string operationDescription);
        void Log();
        void AddDetails(string v);
    }
}
