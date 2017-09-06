using CarWash.Persistence.Models;
using System.Collections.Generic;

namespace CarWash.Persistence.UseCases.WorkDays
{
    public interface IWorkDaysFactory
    {
        List<WorkDay> GetNext5WorkDays();
    }
}
