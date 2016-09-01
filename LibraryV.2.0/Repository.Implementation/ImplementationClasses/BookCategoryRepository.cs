using Domain.Model.Models;
using Model.Dto.Dto;
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
        public IList<CategoryDto>  GetAll()
        {
            /*
                SELECT distinct c.CategoryName as y0_
                FROM   [Book] this_
                join BookCategory c on this_.Category_id = c.Id

             */

            Book bookAlies = null;
            BookCategory category = null;
            CategoryDto categoryDto = null;

            var categories = _session.QueryOver(() => category)
                .JoinAlias(() => category.Books, () => bookAlies)
                .SelectList(list => list
                .Select(Projections.Distinct(Projections.Property(() => bookAlies.Category)))
                .Select(() => category.CategoryName).WithAlias(() => categoryDto.CategoryName))
                
                .TransformUsing(Transformers.AliasToBean<CategoryDto>())
                .List<CategoryDto>();

            return categories;
        }
    }
}
