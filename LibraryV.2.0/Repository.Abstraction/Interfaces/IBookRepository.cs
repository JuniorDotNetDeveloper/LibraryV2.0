using System.Collections.Generic;
using Domain.Model.Common;
using Domain.Model.Models;
using Model.Dto.Dto;
using AuthorsAndCategoriesDto = Model.Dto.Dto.AuthorsAndCategoriesDto;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        void ModifyBook(Book book);
        void AddNewBook(Book book);
        IList<Book> FindAllBooksByLevel(DeveloperLevel level);
        IList<Book> GetAllBooks();
        IList<Book> GetAllGroupedBookByCategoryName(string category);
        IList<AuthorsAndCategoriesDto> GetAuthorsInOneCatgory();
        IList<Book> GetAllBooksBycategoryName(string categoryName);
    }
}
