using Autofac;
using Autofac.Integration.WebApi;
using CarWash.Core.UseCases.Logging;
using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence;
using CarWash.Persistence.Repositories;
using CarWash.Persistence.UseCases.Reservations;
using CarWash.Persistence.UseCases.WorkDays;
using System.Reflection;

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
            builder.RegisterInstance<ILoggingService>(new LoggingService(new LogsRepository(new LoggingDbContext())));
            builder.RegisterInstance<IWorkHoursValidator>(new WorkHoursValidator(new ReservationsRepository(new ApplicationDbContext())));
            builder.RegisterInstance<IAuthRepository>(new AuthRepository(new ApplicationDbContext()));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}