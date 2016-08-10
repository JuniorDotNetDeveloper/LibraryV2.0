using System;

namespace Domain.Model.Models
{
    public class Tag : Entity
    {
        public virtual string TagName { get; set; }

        [Obsolete]
        protected Tag() {}

        public Tag(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentNullException($"{nameof(tagName)} is null or empty");

            TagName = tagName;
        }
    }
}