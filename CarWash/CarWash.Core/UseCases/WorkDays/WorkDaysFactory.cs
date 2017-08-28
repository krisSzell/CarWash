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
                var date = DateTime.Now;
                var dayToAdd = new WorkDay(date);
                if (count > 0)
                {
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    date = date.AddDays(count);
                    dayToAdd = new WorkDay(date);
                }
                if (dayHasWorkingHours(dayToAdd) && _workingDays.Any(wd => wd == dayToAdd.GetDayOfWeek()))
                {
                    workDays.Add(dayToAdd);
                    daysAdded++;
                }
                count++;
            }

            return workDays;
        }

        private bool dayHasWorkingHours(WorkDay day)
        {
            return day.GetRemainingHours().Count > 0 ? true : false;
        }
    }
}
