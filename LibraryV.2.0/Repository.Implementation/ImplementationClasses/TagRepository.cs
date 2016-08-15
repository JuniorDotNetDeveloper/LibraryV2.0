using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
