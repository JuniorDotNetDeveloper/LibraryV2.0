using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class OrderDetailsMap : EntityMap<OrderDetails>
    {
        public OrderDetailsMap()
        {
            References(x => x.Order).Not.Nullable();
            References(x => x.Book).Not.Nullable();

            Map(x => x.EndDate).Not.Nullable();
        }
    }
}
