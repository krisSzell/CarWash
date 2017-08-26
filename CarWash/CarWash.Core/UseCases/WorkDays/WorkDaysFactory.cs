using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Core.Models;

namespace CarWash.Core.UseCases.WorkDays
{
    public class WorkDaysFactory : IWorkDaysFactory
    {
        private readonly IEnumerable<DayOfWeek> _workingDays;

        public WorkDaysFactory()
        {
            _workingDays = new List<DayOfWeek>()
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday
            };
        }

        public List<WorkDay> GetNext5WorkDays()
        {
            List<WorkDay> workDays = new List<WorkDay>();
            int daysAdded = 0;
            int count = 0;
            while (daysAdded < 5)
            {
                var date = new WorkDay(DateTime.Now.AddDays(count++));
                if (_workingDays.Any(wd => wd == date.GetDayOfWeek()))
                {
                    workDays.Add(date);
                }
                daysAdded++;
            }

            return workDays;
        }
    }
}
