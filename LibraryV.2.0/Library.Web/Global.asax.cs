using Castle.Windsor;
using Castle.Windsor.Installer;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure;
using Library.Web.App_Start;
using Library.Web.Filters;
using Library.Web.WindsorUtills;
using NLog;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Library.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NHibernateProfiler.Initialize();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new HandleAllErrorAttribute());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //BundleTable.EnableOptimizations = true;

            var container = new WindsorContainer().Install(FromAssembly.This());
            ServiceLocator.RegisterAll(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
            MappingConfig.RegisterMaps(); 
        }
    }
}
