using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence;
using CarWash.Persistence.Repositories;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarWash
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Autofac configuration
            var appDbContext = new ApplicationDbContext();
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork(appDbContext));
            builder.RegisterInstance<IWorkDaysFormatter>(new WorkDaysFormatter());
            builder.RegisterInstance<IWorkDaysFactory>(new WorkDaysFactory());
            builder.RegisterInstance<IServiceRepository>(new ServiceRepository(appDbContext));
            builder.RegisterInstance<IReservationsRepository>(new ReservationsRepository(appDbContext));
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
