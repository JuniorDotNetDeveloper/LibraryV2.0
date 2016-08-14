using Domain.Model.Models;

namespace Repository.Abstraction.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        BookCategory GetByCategoryName(string name);
    }
}
 