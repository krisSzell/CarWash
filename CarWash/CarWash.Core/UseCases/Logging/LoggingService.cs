using CarWash.Persistence.Models.Logging;
using CarWash.Persistence.Repositories;
using System;

namespace CarWash.Core.UseCases.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogsRepository _logsRepo;
        private FullLog _message;

        public LoggingService(ILogsRepository logsRepo)
        {
            _logsRepo = logsRepo;
            _message = new FullLog();
        }

        public void AddOperationMade(string operationDescription)
        {
            _message.OperationMade = operationDescription;
        }

        public void AddUser(string fullname)
        {
            _message.UserResponsible = fullname;
        }

        public void AddDetails(string details)
        {
            _message.Details = details;
        }

        public void Log()
        {
            _message.TimeStamp = DateTime.Now;
            _logsRepo.PersistLog(_message);
        }
    }
}
