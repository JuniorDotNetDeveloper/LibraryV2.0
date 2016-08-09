using System;

namespace Domain.Model.Models
{
    public class OrderDetails : Entity
    {
        public virtual Order Order { get; protected set; }

        public virtual Book Book { get; protected set; }
        public virtual DateTime EndDate { get; protected set; }
        public virtual int ExtendCount { get; protected set; }

        [Obsolete]
        protected OrderDetails() {}

        public OrderDetails(Order order, Book book)
        {
            if (book == null) throw new ArgumentNullException($"{nameof(book)} is null");
            if (order == null) throw new ArgumentNullException($"{nameof(order)} is null");

            Order = order;
            Book = book;
            EndDate = Order.OrderDate.AddDays(21);
        }
    }
}
