using System;

namespace Domain.Model.Models
{
    public class BookToTags : Entity
    {
        public virtual Book Book{ get; set; }
        public virtual Tag Tag { get; set; }

        [Obsolete]
        protected BookToTags() { }

        public BookToTags(Book book, Tag tag)
        {
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is null");
            if (tag == null)
                throw new ArgumentNullException($"{nameof(tag)} is null");
            Book = book;
            Tag = tag;
        }
    }
}
