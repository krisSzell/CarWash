using CarWash.Persistence.Models;
using System.Collections.Generic;

namespace CarWash.Persistence.UseCases.WorkDays
{
    public interface IWorkDaysFormatter
    {
        List<string> WorkingHoursLeftToString(WorkDay day);
        IList<string> WorkDaysToString(IList<WorkDay> days);
    }
}
