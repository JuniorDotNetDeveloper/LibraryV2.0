using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookRepository
    {
        void ModifyBook(Book book);
        void AddNewBook(Book book);
    }
}
