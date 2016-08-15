using System;
using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class UserToRoleRepository : Repository<UserToRole>, IUserToRoleRepository
    {
        public UserToRoleRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
