using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class OrderMap : EntityMap<Order>
    {
        public OrderMap()
        {
            References(x => x.User).Not.Nullable();
            Map(x => x.OrderDate).Not.Nullable();
        }
    }
}
