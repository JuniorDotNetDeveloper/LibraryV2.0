using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void MakeDetached(Author author);
    }
}
