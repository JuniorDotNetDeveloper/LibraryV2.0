using System.Collections.Generic;
using Domain.Model.Models;
using Domain.Model.Dto;

namespace Repository.Abstraction.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IList<Book> GetCurrentBooks(long userId);
        IList<UsersReadedBooks> GetAllReadedBooks();

        User GetByName(string Username);
    }
}
