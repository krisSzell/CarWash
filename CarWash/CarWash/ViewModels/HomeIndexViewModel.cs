using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.ViewModels
{
    public class HomeIndexViewModel
    {
        private IList<WorkDay> _upcomingWeekWorkingDays;
        private IList<WorkHour> _workingHoursLeft;

        public HomeIndexViewModel()
        {
            _upcomingWeekWorkingDays = new List<WorkDay>();
            setUpcomingWeekWorkingDays();
        }

        public IList<string> GetUpcomingWeekDays()
        {
            var upcomingDays = new List<string>();

            foreach (var day in _upcomingWeekWorkingDays)
            {
                string dayRepresentation = day.GetDay() + "." + day.GetMonth();
                upcomingDays.Add(dayRepresentation);
            }

            return upcomingDays;
        }
        public IList<string> GetWorkingHoursLeft()
        {
            var workingHoursLeft = new List<string>();

            foreach (var hour in _workingHoursLeft)
            {
                
                workingHoursLeft.Add(hour.ToString());
            }

            return workingHoursLeft;
        }

        private void setUpcomingWeekWorkingDays()
        {
            for (int i = 0; i < 7; i++)
            {
                var date = new WorkDay(DateTime.Now.AddDays(i));
                _upcomingWeekWorkingDays.Add(date);
            }
        }
        private void setCurrentDayWorkingHours()
        {
            var currentDay = new WorkDay(DateTime.Now);
            _workingHoursLeft = currentDay.GetRemainingHours();
        }
    }
}