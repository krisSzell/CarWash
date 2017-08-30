using AutoMapper;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.UseCases.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWash.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<ReservationDto, Reservation>().ConvertUsing<ReservationDtoToReservationConverter>();
            });
        }
    }
}