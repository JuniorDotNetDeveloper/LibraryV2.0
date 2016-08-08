using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class UserToRoleMap : EntityMap<UserToRole>
    {
        public UserToRoleMap()
        {
            References(x => x.Role).Not.Nullable();
            References(x => x.User).Not.Nullable();
        }
    }
}
