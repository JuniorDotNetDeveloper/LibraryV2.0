using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class ClaimMap : EntityMap<Claim>
    {
        public ClaimMap()
        {
            References(x => x.User).Not.Nullable().ForeignKey("FK_Reservation_Users");
            References(x => x.Book).Not.Nullable().ForeignKey("FK_Reservation_Books");
            Map(x => x.ReservationDate).Not.Nullable();
        }
    }
}
