using System;

namespace Domain.Model.Models
{
    public class OrderDetails : Entity
    {
        public virtual Order Order { get; protected set; }

        public virtual Book Book { get; protected set; }
        public virtual DateTime EndDate { get; protected set; }

        [Obsolete]
        protected OrderDetails() {}
    }
}
