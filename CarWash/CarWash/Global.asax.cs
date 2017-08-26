using Autofac;
using Autofac.Integration.Mvc;
using CarWash.Core.UseCases.WorkDays;
using CarWash.Persistence;
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
            var builder = new ContainerBuilder();
            builder.RegisterControllers((typeof(MvcApplication).Assembly));
            builder.RegisterInstance<IUnitOfWork>(new UnitOfWork(new ApplicationDbContext()));
            builder.RegisterInstance<IWorkDaysFormatter>(new WorkDaysFormatter());
            builder.RegisterInstance<IWorkDaysFactory>(new WorkDaysFactory());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
