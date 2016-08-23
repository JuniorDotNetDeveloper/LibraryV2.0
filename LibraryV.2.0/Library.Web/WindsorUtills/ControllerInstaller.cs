using System;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Library.Web.WindsorUtills
{
    public class ControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installation configuration
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().LifestyleTransient());
        }


        /// <summary>
        /// Find Controller classes
        /// </summary>
        /// <returns></returns>
        private static BasedOnDescriptor FindControllers()
        {
            return Classes.FromThisAssembly().BasedOn<IController>()
                          .If(t => t.Name.EndsWith("Controller"));
        }
    }
}