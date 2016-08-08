using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        void ModifyBook(Book book);
        void AddNewBook(Book book);
    }
}
