using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaim.Mapping
{
    public class OrderDetailsMap : EntityMap<OrderDetails>
    {
        public OrderDetailsMap()
        {
            Map(x => x.OrderId).Not.Nullable();
        }
    }
}
