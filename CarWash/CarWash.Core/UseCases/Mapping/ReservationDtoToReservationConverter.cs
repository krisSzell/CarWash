using AutoMapper;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using System;

namespace CarWash.Core.UseCases.Mapping
{
    public class ReservationDtoToReservationConverter : ITypeConverter<ReservationDto, Reservation>
    {
        public Reservation Convert(ReservationDto source, 
            Reservation destination, 
            ResolutionContext context)
        {
            var reservation = new Reservation();
            reservation.Schedule = createSchedule(source);
            reservation.Service = source.Service;
            reservation.Status = new Status() { IsAccepted = false, IsArchived = false };

            return reservation;
        }

        private Schedule createSchedule(ReservationDto source)
        {
            var schedule = new Schedule();
            schedule.StartDate = retrieveDateBasedOnSource(source);
            schedule.EndDate = schedule.StartDate.AddMinutes(source.Service.DurationInMinutes);
            schedule.IsAvailable = false;

            return schedule;
        }

        private Tuple<int, int> retrieveHourFromString(string source)
        {
            string[] sourceSplitted = source.Split(':');
            int hour = Int32.Parse(sourceSplitted[0]);
            int minute = Int32.Parse(sourceSplitted[1]);

            return new Tuple<int, int>(hour, minute);
        }

        private DateTime retrieveDateBasedOnSource(ReservationDto source)
        {
            var retrievedHour = retrieveHourFromString(source.Date.Hour);

            return new DateTime(source.Date.Year, source.Date.Month, source.Date.Day, retrievedHour.Item1, retrievedHour.Item2, 0);
        }
    }
}
