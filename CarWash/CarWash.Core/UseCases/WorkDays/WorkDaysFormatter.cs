using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Core.Models;

namespace CarWash.Core.UseCases.WorkDays
{
    public class WorkDaysFormatter : IWorkDaysFormatter
    {
        public IList<string> WorkDaysToString(IList<WorkDay> days)
        {
            var upcomingDays = new List<string>();

            foreach (var day in days)
            {
                string dayRepresentation = day.GetDay() + "." + day.GetMonth();
                upcomingDays.Add(dayRepresentation);
            }

            return upcomingDays;
        }

        public IList<string> WorkingHoursLeftToString(WorkDay day)
        {
            var hoursLeft = day.GetRemainingHours();
            var hoursLeftString = new List<string>();

            foreach (var hour in hoursLeft)
            {
                hoursLeftString.Add(hour.ToString());
            }

            return hoursLeftString;
        }
    }
}
