using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.UseCases.WorkDays
{
    public interface IWorkDaysFormatter
    {
        List<string> WorkingHoursLeftToString(WorkDay day);
        IList<string> WorkDaysToString(IList<WorkDay> days);
    }
}
