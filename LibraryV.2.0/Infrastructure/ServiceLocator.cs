
using Domain.Model.Models;
using Ninject;
using Repository.Abstraction.Interfaces;
using Repository.Implementation.ImplementationClasses;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static void RegisterAll()
        {
            _kernel.Bind<IBookRepository>().To<BookRepository>();
            //_kernel.Bind<IRepository<Author>>().To<AuthorRepository>();
        }



        public static T Resolver<T>() => _kernel.Get<T>();
    }
}