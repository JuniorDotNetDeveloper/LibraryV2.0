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
            _kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<IAuthorToBookRepository>().To<AuthorToBookRepository>();
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<IRoleRepository>().To<RoleRepository>();
        }



        public static T Resolver<T>() => _kernel.Get<T>();
    }
}