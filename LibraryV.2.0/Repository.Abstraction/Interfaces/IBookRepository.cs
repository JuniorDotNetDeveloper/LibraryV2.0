using System.Collections.Generic;
using Domain.Model.Common;
using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        void ModifyBook(Book book);
        void AddNewBook(Book book);
        IList<Book> FindAllBooksByLevel(DeveloperLevel level);
    }
}
