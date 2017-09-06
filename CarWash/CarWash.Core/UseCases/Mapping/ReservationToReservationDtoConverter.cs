using AutoMapper;
using CarWash.Persistence;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using System.Linq;

namespace CarWash.Core.UseCases.Mapping
{
    public class ReservationToReservationDtoConverter : ITypeConverter<Reservation, ReservationDto>
    {
        private readonly ApplicationDbContext _context;

        public ReservationToReservationDtoConverter()
        {
            _context = new ApplicationDbContext();
        }

        public ReservationDto Convert(Reservation source,
            ReservationDto destination,
            ResolutionContext context)
        {
            var reservation = new ReservationDto();
            reservation.Date = retrieveDateBasedOnSource(source);
            reservation.Service = source.Service;
            reservation.Status = source.Status;
            reservation.ReservationId = source.ReservationId;
            reservation.Username = getUsernameBasedOnSource(source);

            return reservation;
        }

        private Date retrieveDateBasedOnSource(Reservation source)
        {
            Date result = new Date()
            {
                Year = source.Schedule.StartDate.Year,
                Month = source.Schedule.StartDate.Month,
                Day = source.Schedule.StartDate.Day,
                Hour = source.Schedule.StartDate.ToShortTimeString()
            };

            return result;
        }

        private string getUsernameBasedOnSource(Reservation source)
        {
            return _context.Users
                .SingleOrDefault(u => u.Id == source.UserId)
                .UserName;
        }
    }
}
