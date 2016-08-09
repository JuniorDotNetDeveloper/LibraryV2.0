using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class AuthorToBookRepository : Repository<AuthorToBook>, IAuthorToBookRepository
    {
        public override void Create(AuthorToBook entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
