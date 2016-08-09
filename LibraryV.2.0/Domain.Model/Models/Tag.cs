using System;

namespace Domain.Model.Models
{
    public class Tag : Entity
    {
        public virtual string TagName { get; set; }

        [Obsolete]
        protected Tag() {}
    }
}