using System.Collections.Generic;
using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IList<Book> GetCurrentBooks();
    }
}
