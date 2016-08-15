using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class AuthorToBookRepository : Repository<AuthorToBook>, IAuthorToBookRepository
    {
        public AuthorToBookRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
