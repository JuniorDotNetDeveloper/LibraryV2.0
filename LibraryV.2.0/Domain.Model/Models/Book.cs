using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public enum BookStatus : byte { Busy, Free }

    public class Book : Entity 
    {
        public virtual string Name { get; protected set; }
        public virtual DateTime PublicationDate { get; protected set; }
        public virtual string Description { get; set; }
        public virtual BookStatus Status { get; set; } = BookStatus.Free;
        public virtual IList<Author> Authors { get; protected set; }
        public virtual IList<string> Tags { get; set; }
        public virtual IList<Comment> Comments{ get; }
        public virtual Rating Rating { get; set; }
        public virtual int HowOldIs => DateTime.Now.Year - PublicationDate.Year;

        [Obsolete]
        protected Book() { }

        public Book(List<Author> authors, string bookName, DateTime publicationDate, string description)
        {
            ValidateInput(authors, bookName, publicationDate, description);

            Authors = authors;
            Name = bookName;
            PublicationDate = publicationDate;
        }

        private void ValidateInput(List<Author> authors, string bookName, DateTime publicationDate, string description)
        {
            if (string.IsNullOrEmpty(bookName))
                throw new ArgumentNullException($"Next field named: {nameof(bookName)} is null or empty");
            if (publicationDate == null)
                throw new ArgumentNullException($"{nameof(publicationDate)} is requared");
            if (authors == null) throw new ArgumentNullException($"{nameof(authors)} is requared");

            Description = description ?? "Without description";
        }
    }
}
