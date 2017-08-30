using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Persistence.Models;

namespace CarWash.Persistence.UseCases.WorkDays
{
    public class WorkDaysFormatter : IWorkDaysFormatter
    {
        public IList<string> WorkDaysToString(IList<WorkDay> days)
        {
            var upcomingDays = new List<string>();

            foreach (var day in days)
            {
                string dayNo = day.GetDay() < 10 ? $"0{day.GetDay()}" : $"{day.GetDay()}";
                string monthNo = day.GetMonth() < 10 ? $"0{day.GetMonth()}" : $"{day.GetMonth()}";
                string dayRepresentation = dayNo + "." + monthNo;
                upcomingDays.Add(dayRepresentation);
            }

            return upcomingDays;
        }

        public List<string> WorkingHoursLeftToString(WorkDay day)
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
