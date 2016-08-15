using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class BookToTagsRepository : Repository<BookToTags>, IBookToTagsRepository
    {
        public BookToTagsRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
