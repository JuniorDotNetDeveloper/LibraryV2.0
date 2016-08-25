using System.Collections.Generic;
using Domain.Model.Models;
using FluentNHibernate.Conventions;
using Model.Dto.Dto;
using NHibernate.Criterion;
using NHibernate.Transform;
using Remotion.Linq;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }


        public void MakeDetached(Author author)
        {
            _session.Evict(author);
        }

        public IList<AuthorsAndCategoriesDto> GetAuthorsWithSpecifyCategory(string category)
        {

            AuthorToBook authorToBookAlies = null;
            Author authorAlies = null;
            Book bookAlies = null;
            BookCategory bookCategoryAlies = null;
            AuthorsAndCategoriesDto dtoAlies = null;

            var subquery = QueryOver.Of(() => bookAlies)
                .JoinAlias(() => bookAlies.Category, () => bookCategoryAlies)
                .JoinQueryOver(() => bookAlies.Authors, () => authorToBookAlies)
                .Where(() => bookCategoryAlies.CategoryName == category)
                .Select(x => authorToBookAlies.Author.Id);

            var result = _session.QueryOver(() => authorAlies)
                .SelectList(list => list
                    .Select(Projections.Distinct(Projections.Property(() => authorAlies.FirstName))).WithAlias(() => dtoAlies.FirstName)
                    .Select(() => authorAlies.LastName).WithAlias(() => dtoAlies.LastName)
                )

                .WithSubquery.WhereProperty(() => authorAlies.Id).In(subquery)
                //.WithSubquery.WhereProperty()
                .TransformUsing(Transformers.AliasToBean<AuthorsAndCategoriesDto>())
                .List<AuthorsAndCategoriesDto>();
            return result;
        }
    }
}
