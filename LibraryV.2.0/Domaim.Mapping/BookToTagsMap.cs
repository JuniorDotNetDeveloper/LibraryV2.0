using Domaim.Mapping;
using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class BookToTagsMap : EntityMap<BookToTags>
    {
        public BookToTagsMap()
        {
            References(x => x.Book).Not.Nullable().ForeignKey("FK_BookToTags_Books").Cascade.Delete();
            References(x => x.Tag).Not.Nullable().ForeignKey("FK_BookToTags_Tags").Cascade.All();
        }
    }
}
