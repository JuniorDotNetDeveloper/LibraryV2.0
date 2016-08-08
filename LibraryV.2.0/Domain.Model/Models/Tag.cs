using System;

namespace Domain.Model.Models
{
    public class Tag : Entity
    {
        public virtual string Tags { get; set; }

        [Obsolete]
        protected Tag() {}
    }
}
