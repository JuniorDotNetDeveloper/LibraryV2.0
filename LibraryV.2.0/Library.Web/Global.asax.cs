using Castle.Windsor;
using Castle.Windsor.Installer;
using Infrastructure;
using Library.Web.App_Start;
using Library.Web.WindsorUtills;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new WindsorContainer().Install(FromAssembly.This());
            ServiceLocator.RegisterAll(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
            MappingConfig.RegisterMaps();
        }
    }
}
