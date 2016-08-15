using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public BookCategory GetByCategoryName(string name)
        {
            BookCategory category = _session.QueryOver<BookCategory>()
                .Where(x => x.CategoryName == name)
                .SingleOrDefault();
            return category;
        }
    }
}
