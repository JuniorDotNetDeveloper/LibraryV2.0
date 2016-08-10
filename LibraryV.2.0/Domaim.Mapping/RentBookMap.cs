using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class RentBookMap : EntityMap<RentBook>
    {
        public RentBookMap()
        {
            References(x => x.User).Not.Nullable().ForeignKey("FK_RentBook_Users");
            Map(x => x.RentDate).Not.Nullable();
        }
    }
}
