using System;

namespace Domain.Model.Models
{
    public class Order : Entity
    {

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }

        internal Order(Book book, User user)
        {
            if (book == null)
                throw new ArgumentNullException("book");
            if (user == null)
                throw new ArgumentNullException("user");
        }

        [Obsolete]
        protected Order() { }
    }
}
