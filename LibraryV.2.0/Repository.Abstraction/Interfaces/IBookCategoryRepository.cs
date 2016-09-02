using Domain.Model.Models;
using Model.Dto.Dto;
using System.Collections.Generic;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        BookCategory GetByCategoryName(string name);
        IList<CategoryDto> GetNotEmptyCategories();
        IList<BookCategory> GetAllCategories();
    }
}
 