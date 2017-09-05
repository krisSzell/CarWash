using AutoMapper;
using CarWash.Core.UseCases.Mapping;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;

namespace CarWash.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<ReservationDto, Reservation>().ConvertUsing<ReservationDtoToReservationConverter>();
                config.CreateMap<Reservation, ReservationDto>().ConvertUsing<ReservationToReservationDtoConverter>();
            });
        }
    }
}