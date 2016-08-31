using Domain.Model.Models;
using System.Collections.Generic;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        BookCategory GetByCategoryName(string name);
        IList<BookCategory> GetAll();
    }
}
 