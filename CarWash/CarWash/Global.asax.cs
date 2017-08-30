using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CarWash.App_Start;
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
            // Automapper config init 
            AutoMapperConfig.Initialize();

            // Autofac configuration
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = AutofacConfig.Configure();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
