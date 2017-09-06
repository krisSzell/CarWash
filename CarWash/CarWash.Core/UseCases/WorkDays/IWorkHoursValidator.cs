using CarWash.Persistence.Models;
using System.Collections.Generic;

namespace CarWash.Core.UseCases.WorkDays
{
    public interface IWorkHoursValidator
    {
        void CheckAndUpdate(List<WorkDay> days);
    }
}
