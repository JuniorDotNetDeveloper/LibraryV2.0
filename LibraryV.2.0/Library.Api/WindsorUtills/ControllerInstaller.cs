
using System.Diagnostics.Contracts;
using System.Web.Http;
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
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
        }


        /// <summary>
        /// Find Controller classes
        /// </summary>
        /// <returns></returns>
        private static BasedOnDescriptor FindControllers()
        {
            Contract.Ensures(Contract.Result<BasedOnDescriptor>() != null);
            return Classes.FromThisAssembly().BasedOn<ApiController>()
                          .If(t => t.Name.EndsWith("Controller"));
        }
    }
}