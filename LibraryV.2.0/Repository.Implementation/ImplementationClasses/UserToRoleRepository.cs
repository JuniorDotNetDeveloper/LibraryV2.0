using System;
using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class UserToRoleRepository : Repository<UserToRole>, IUserToRoleRepository
    {
        public override void Create(UserToRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
