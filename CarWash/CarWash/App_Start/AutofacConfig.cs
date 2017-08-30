using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CarWash.Core.Dtos;
using CarWash.Core.Models;
using CarWash.Core.UseCases.Mapping;
using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence;
using CarWash.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

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
            var appDbContext = new ApplicationDbContext();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork(appDbContext));
            builder.RegisterInstance<IWorkDaysFormatter>(new WorkDaysFormatter());
            builder.RegisterInstance<IWorkDaysFactory>(new WorkDaysFactory());
            builder.RegisterInstance<IServiceRepository>(new ServiceRepository(appDbContext));
            builder.RegisterInstance<IReservationsRepository>(new ReservationsRepository(appDbContext));
        }
    }
}