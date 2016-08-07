using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models
{
    public class OrderDetails : Entity
    {
        public virtual long OrderId { get; protected set; }

        public virtual long BookId { get; protected set; }

        [Obsolete]
        protected OrderDetails() {}
    }
}
