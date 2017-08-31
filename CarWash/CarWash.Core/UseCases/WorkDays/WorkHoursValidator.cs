using CarWash.Persistence.Models;
using CarWash.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.UseCases.WorkDays
{
    public class WorkHoursValidator : IWorkHoursValidator
    {
        private IReservationsRepository _reservations;

        public WorkHoursValidator(IReservationsRepository repository)
        {
            _reservations = repository;
        }

        public void CheckAndUpdate(List<WorkDay> days)
        {
            var schedules = _reservations.GetAll().Select(r => r.Schedule).ToList();

            foreach (var day in days)
            {
                var hoursScheduled = getListOfScheduledHours(schedules, day);

                var remainingHours = day.GetRemainingHours();
                foreach (var hour in hoursScheduled)
                {
                    remainingHours.Remove(hour);
                }
            }
        }

        private List<WorkHour> getListOfScheduledHours(List<Schedule> schedules, WorkDay day)
        {
            var listOfHoursScheduled = new List<WorkHour>();

            foreach (var schedule in schedules)
            {
                if (schedule.StartDate.Day == day.GetDay() && schedule.StartDate.Month == day.GetMonth())
                {
                    DateTime dateFlag = schedule.EndDate;
                    while (dateFlag > schedule.StartDate)
                    {
                        dateFlag = dateFlag.Subtract(TimeSpan.FromMinutes(15));
                        listOfHoursScheduled.Add(new WorkHour(dateFlag.Hour, dateFlag.Minute));
                    }
                }
            }

            return listOfHoursScheduled;
        }
    }
}
