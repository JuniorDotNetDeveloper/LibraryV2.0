using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        public BookCategory GetByCategoryName(string name)
        {
            BookCategory category = _session.QueryOver<BookCategory>()
                .Where(x => x.CategoryName == name)
                .SingleOrDefault();
            return category;
        }
    }
}
