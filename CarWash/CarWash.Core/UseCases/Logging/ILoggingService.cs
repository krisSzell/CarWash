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
