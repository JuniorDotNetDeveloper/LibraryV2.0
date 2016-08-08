using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class AuthorToBookMap : EntityMap<AuthorToBook>
    {
        public AuthorToBookMap()
        {
            References(x => x.Author).Not.Nullable();
            References(x => x.Book).Not.Nullable();
        }
    }
}
