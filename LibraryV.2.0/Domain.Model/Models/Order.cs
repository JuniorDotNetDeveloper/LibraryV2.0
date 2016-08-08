using System;

namespace Domain.Model.Models
{
    public class Order : Entity
    {
        public virtual DateTime OrderDate { get; }
        public virtual User User { get; protected set; }
        

        internal Order(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
        }

        [Obsolete]
        protected Order() { }
    }
}
