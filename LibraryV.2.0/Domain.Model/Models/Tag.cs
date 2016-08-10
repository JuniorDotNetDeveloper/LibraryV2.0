using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class Tag : Entity
    {
        public virtual string TagName { get; set; }
        public virtual IList<BookToTags> Books { get; set; }

        [Obsolete]
        protected Tag() {}

        public Tag(string tagName, IList<BookToTags> books = null)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentNullException($"{nameof(tagName)} is null or empty");

            TagName = tagName;
        }
    }
}