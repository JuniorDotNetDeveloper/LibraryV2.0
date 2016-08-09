using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class RoleRepository  : Repository<Role>, IRoleRepository
    {
        public override void Create(Role entity)
        {
            throw new System.NotImplementedException();
        }
    }
}