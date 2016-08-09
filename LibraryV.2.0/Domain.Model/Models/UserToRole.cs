using System;

namespace Domain.Model.Models
{
    public class UserToRole : Entity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        [Obsolete]
        protected UserToRole() {}

        public UserToRole(User user, Role role)
        {
            User = user;
            Role = role;
        }
    }
}
