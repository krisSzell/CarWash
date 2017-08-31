using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.UseCases.WorkDays
{
    public interface IWorkHoursValidator
    {
        void CheckAndUpdate(List<WorkDay> days);
    }
}
