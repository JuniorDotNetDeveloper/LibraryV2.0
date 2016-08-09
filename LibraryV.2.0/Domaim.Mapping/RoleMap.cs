using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class RoleMap : EntityMap<Role>
    {
        public RoleMap()
        {
            Map(x => x.RoleName).Not.Nullable().UniqueKey("UQ_RoleName");
        }
    }
}
