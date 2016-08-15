using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}