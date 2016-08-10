using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class RentBookDetailsMap : EntityMap<RentBookDetails>
    {
        public RentBookDetailsMap()
        {
            References(x => x.RentBook).Not.Nullable().ForeignKey("FK_RentBookDetails_RentBooks").Cascade.All(); ;
            References(x => x.Book).Not.Nullable().ForeignKey("FK_RentBookDetails_Books");

            Map(x => x.EndDate).Not.Nullable();
            Map(x => x.DelayCount);
        }
    }
}
