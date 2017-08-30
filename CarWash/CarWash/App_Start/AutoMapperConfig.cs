using AutoMapper;
using CarWash.Core.Dtos;
using CarWash.Core.Models;
using CarWash.Core.UseCases.Mapping;
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