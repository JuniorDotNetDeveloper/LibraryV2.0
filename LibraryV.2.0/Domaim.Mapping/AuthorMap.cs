using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class AuthorMap : EntityMap<Author>
    {
        protected AuthorMap()
        {
            Map(x => x.FirstName).Not.Nullable().UniqueKey("UQ_FirstLastName");
            Map(x => x.LastName).Not.Nullable().UniqueKey("UQ_FirstLastName");
            HasMany(x => x.PersonalBooks);
            
        }
    }
}
