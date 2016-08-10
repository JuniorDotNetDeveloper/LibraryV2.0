using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class UserToRoleMap : EntityMap<UserToRole>
    {
        public UserToRoleMap()
        {
            References(x => x.Role).Not.Nullable().ForeignKey("FK_UserToRole_Roles").Cascade.All();
            References(x => x.User).Not.Nullable().ForeignKey("FK_UserToRole_Users").Cascade.All();
        }
    }
}
