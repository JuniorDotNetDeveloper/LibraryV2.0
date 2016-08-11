using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class Role : Entity
    {
        public virtual string RoleName { get; set; }
        public virtual IList<UserToRole> Users { get; set; }
        [Obsolete]
        protected Role() {}

        public Role(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentNullException($"{nameof(roleName)} is  null or empty");
            RoleName = roleName;    
        }
    }
}
