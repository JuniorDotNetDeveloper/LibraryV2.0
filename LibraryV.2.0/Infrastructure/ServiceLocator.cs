using Ninject.Extensions.Conventions;
using Ninject;
using Repository.Abstraction.Interfaces;
using Repository.Implementation.ImplementationClasses;
using System.Reflection;
using Domain.Model.Models;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static void RegisterAll()
        {
            _kernel.Bind<ISessionProvider>().To<SessionProvider>().InThreadScope();
            _kernel.Bind(x =>
            {
                x.From("Repository.Implementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                //.FromThisAssembly() // Scans currently assembly
                .SelectAllClasses().InNamespaceOf<Repository<Entity>>() // Retrieve all non-abstract classes
                .Join.From("Repository.Abstraction, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                .SelectAllClasses().InheritedFrom<IRepository<Entity>>().Excluding<SessionProvider>()

                .BindDefaultInterface() // Binds the default interface to them;
            ;
            });




            //_kernel.Bind<IBookRepository>().To<BookRepository>();
            //_kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            //_kernel.Bind<IUserRepository>().To<UserRepository>();
            //_kernel.Bind<IAuthorToBookRepository>().To<AuthorToBookRepository>();
            //_kernel.Bind<IUserToRoleRepository>().To<UserToRoleRepository>();
            //_kernel.Bind<IRoleRepository>().To<RoleRepository>();
            //_kernel.Bind<IBookCategoryRepository>().To<BookCategoryRepository>();
            //_kernel.Bind<IBookToTagsRepository>().To<BookToTagsRepository>();
        }



        public static T Resolver<T>() => _kernel.Get<T>();
    }
}