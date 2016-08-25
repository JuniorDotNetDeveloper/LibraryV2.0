using Repository.Abstraction.Interfaces;
using Repository.Implementation.ImplementationClasses;
using Domain.Model.Models;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System.Reflection;
using NHibernate.Util;
using System.Linq;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        private static IKernel _kernel;

        public static void RegisterAll()
        {
            
            _kernel.Register(Component.For<ISessionProvider>().ImplementedBy<SessionProvider>().LifestylePerThread());

            var interfaces = Assembly.Load(typeof(IRoleRepository).Assembly.FullName).GetTypes().Where(type => type.IsInterface && type.IsPublic).ToList();

            _kernel.Register(Classes
                .FromAssemblyNamed("Repository.Implementation")
                .Where(x => x.GetInterfaces().Intersect(interfaces).Any())
                .LifestyleTransient()
                .WithService.DefaultInterfaces());
        }

        public static void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.Register(Component.For<ISessionProvider>().ImplementedBy<SessionProvider>().LifestylePerThread());

            //_kernel.Bind(x =>
            //{
            //    x.From("Repository.Implementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            //    .SelectAllClasses().InNamespaceOf<Repository<Entity>>() // Retrieve all non-abstract classes
            //    .Join.From("Repository.Abstraction, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            //    .SelectAllClasses().InheritedFrom<IRepository<Entity>>().Excluding<SessionProvider>()

            //    .BindDefaultInterface(); // Binds the default interface to them;

            //});

            //var interfaces = Assembly.Load("Repository.Abstraction").GetTypes().Where(type => type.IsInterface && type.IsPublic).ToList();
            var interfaces = Assembly.Load(typeof(IRoleRepository).Assembly.FullName).GetTypes().Where(type => type.IsInterface && type.IsPublic).ToList();

            _kernel.Register(Classes
                .FromAssemblyNamed("Repository.Implementation")
                .Where(x => x.GetInterfaces().Intersect(interfaces).Any())
                .LifestyleTransient()
                .WithService.DefaultInterfaces());



            //_kernel.Bind<IBookRepository>().To<BookRepository>();
            //_kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            //_kernel.Bind<IUserRepository>().To<UserRepository>();
            //_kernel.Bind<IAuthorToBookRepository>().To<AuthorToBookRepository>();
            //_kernel.Bind<IUserToRoleRepository>().To<UserToRoleRepository>();
            //_kernel.Bind<IRoleRepository>().To<RoleRepository>();
            //_kernel.Bind<IBookCategoryRepository>().To<BookCategoryRepository>();
            //_kernel.Bind<IBookToTagsRepository>().To<BookToTagsRepository>();
        }



        public static T Get<T>() =>     _kernel.Resolve<T>();
    }
}