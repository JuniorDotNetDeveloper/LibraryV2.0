using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class RentBook : Entity
    {
        public virtual DateTime RentDate { get; }
        public virtual User User { get; protected set; }

        public virtual IList<RentBookDetails> RentDetails { get; set; }

        internal RentBook(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
        }

        [Obsolete]
        protected RentBook() { }
    }
}
