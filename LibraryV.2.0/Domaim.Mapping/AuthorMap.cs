using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class AuthorMap : EntityMap<Author>
    {
        protected AuthorMap()
        {
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();

            HasMany(x => x.PersonalBooks).Cascade.SaveUpdate().Inverse();
            References(x => x.PersonalBooks);
        }
    }
}
