using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class TagMap : EntityMap<Tag>
    {
        public TagMap()
        {
            Map(x => x.TagName).Not.Nullable().UniqueKey("TagName");
            HasMany(x => x.Books).Inverse();
        }
    }
}
