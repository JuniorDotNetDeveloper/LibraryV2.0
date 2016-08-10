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
            if (user == null)
                throw new ArgumentNullException($"{nameof(user)} is null");
            if (role == null)
                throw new ArgumentNullException($"{nameof(role)} is null");
            User = user;
            Role = role;
        }
    }
}
