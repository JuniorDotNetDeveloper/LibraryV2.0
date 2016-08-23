using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class CoverMap : EntityMap<Cover>
    {
        public CoverMap()
        {
            HasMany(x => x.Books).Inverse();
        }
    }
}
