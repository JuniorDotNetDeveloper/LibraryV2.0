using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.TelephoneNumber);
            HasMany(x => x.CurrentBooks).Inverse();
        }
    }
}
