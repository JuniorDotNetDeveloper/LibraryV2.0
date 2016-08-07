using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; }
        public virtual User User { get; protected set; }
        public virtual IList<Book> Books { get; protected set; }

        internal Order(User user, IList<Book> books )
        {
            if (books == null)
                throw new ArgumentNullException("book");
            if (user == null)
                throw new ArgumentNullException("user");
        }

        [Obsolete]
        protected Order() { }
    }
}
