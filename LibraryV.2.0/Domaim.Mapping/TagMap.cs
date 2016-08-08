using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class TagMap : EntityMap<Tag>
    {
        public TagMap()
        {
            Map(x => x.Tags).Not.Nullable().Unique();
        }
    }
}
