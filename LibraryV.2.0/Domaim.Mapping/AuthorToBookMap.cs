using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class AuthorToBookMap : EntityMap<AuthorToBook>
    {
        public AuthorToBookMap()
        {
            References(x => x.Author).Not.Nullable().ForeignKey("FK_AuthorToBook_Authors").Cascade.SaveUpdate().UniqueKey("UQ_AuthorToBook");
            References(x => x.Book).Not.Nullable().ForeignKey("FK_AuthorToBook_Books").UniqueKey("UQ_AuthorToBook");
        }
    }
}
