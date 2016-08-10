using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class BookCategory : Entity
    {
        public virtual string CategoryName { get; protected set; }
        public virtual string Description { get; set; }
        public virtual IList<Book> Books { get; protected set; } = new List<Book>();

        [Obsolete]
        protected BookCategory() {}

        public BookCategory(string category, string description = null)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException($"{nameof(category)} is null or empty");
            CategoryName = category;
            Description = description;
        }
    }
}
