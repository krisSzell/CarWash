using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.ViewModels
{
    public class HomeIndexViewModel
    {
        private IList<DateTime> _upcomingWeekDates;
        private IList<DateTime> _currentDayWorkingHours;

        public HomeIndexViewModel()
        {
            _upcomingWeekDates = new List<DateTime>();
            setUpcomingWeekDates();
        }

        public IList<string> GetUpcomingWeekDays()
        {
            var upcomingDays = new List<string>();

            foreach (var day in _upcomingWeekDates)
            {
                string dayRepresentation = day.Day + "." + day.Month;
                upcomingDays.Add(dayRepresentation);
            }

            return upcomingDays;
        }



        private void setUpcomingWeekDates()
        {
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(i);
                _upcomingWeekDates.Add(date);
            }
        }

        private void setCurrentDayWorkingHours()
        {
            var currentDay = DateTime.Now;

        }
    }
}