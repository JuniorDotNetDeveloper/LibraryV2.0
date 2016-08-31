using Domain.Model.Models;
using NHibernate.Criterion;
using NHibernate.Transform;
using Repository.Abstraction.Interfaces;
using System.Collections.Generic;

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
        public IList<BookCategory>  GetAll()
        {
            Book bookAlies = null;
            

            var categories = _session.QueryOver(() => bookAlies)
                .SelectList(list => list
                    .Select(Projections.Distinct(Projections.Property(() => bookAlies.Category))))
                    .TransformUsing(Transformers.AliasToBean<BookCategory>())
                    .List<BookCategory>();
                    
            return categories;
        }
    }
}
