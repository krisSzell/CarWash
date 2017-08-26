using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.UseCases.WorkDays
{
    public interface IWorkDaysFormatter
    {
        IList<string> WorkingHoursLeftToString(WorkDay day);
        IList<string> WorkDaysToString(IList<WorkDay> days);
    }
}
