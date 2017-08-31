using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CarWash.Persistence.Dtos;
using CarWash.Persistence.Models;
using CarWash.Persistence.UseCases.Mapping;
using CarWash.Persistence.UseCases.WorkDays;
using CarWash.Persistence;
using CarWash.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CarWash.Persistence.UseCases.Reservations;
using CarWash.Core.UseCases.WorkDays;

namespace CarWash.App_Start
{
    public class AutofacConfig
    {
        public static AutofacWebApiDependencyResolver Configure()
        {
            var builder = new ContainerBuilder();
            registerInstances(builder);

            var container = builder.Build();

            return new AutofacWebApiDependencyResolver(container);
        }

        private static void registerInstances(ContainerBuilder builder)
        {
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork(new ApplicationDbContext()));
            builder.RegisterInstance<IWorkDaysFormatter>(new WorkDaysFormatter());
            builder.RegisterInstance<IWorkDaysFactory>(new WorkDaysFactory());
            builder.RegisterInstance<IReservationsService>(new ReservationsService(new UnitOfWork(new ApplicationDbContext())));
            builder.RegisterInstance<IWorkHoursValidator>(new WorkHoursValidator(new ReservationsRepository(new ApplicationDbContext())));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}