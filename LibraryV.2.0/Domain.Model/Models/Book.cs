using System;
using System.Collections.Generic;
using Domain.Model.Common;

namespace Domain.Model.Models
{
    public class Book : Entity 
    {
        public virtual string Name { get; protected set; }
        public virtual DateTime PublicationDate { get; protected set; }
        public virtual string Description { get; set; }
        public virtual BookStatus Status { get; set; }
        public virtual DeveloperLevel FilterLevel { get; set; }
        public virtual int? Rating { get; set; }
        public virtual IList<Author> Authors { get; protected set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Comment> Comments { get; }
        //public virtual int HowOldIs => DateTime.Now.Year - PublicationDate.Year;

        [Obsolete]
        protected Book() { }

        public Book(List<Author> authors, string bookName, DateTime publicationDate, string description)
          
        {
            ValidateInput(authors, bookName, publicationDate, description);

            Authors = authors;
            Name = bookName;
            PublicationDate = publicationDate;
        }

        public Book(Author author, string bookName, DateTime publicationDate, string description = null)
            : this(new List<Author> {author}, bookName, publicationDate, description)
        {
            
        }

        private void ValidateInput(List<Author> authors, string bookName, DateTime publicationDate, string description)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentNullException($"Next field named: {nameof(bookName)} is null or empty");
            if (publicationDate == null)
                throw new ArgumentNullException($"{nameof(publicationDate)} is requared");
            if (authors == null) throw new ArgumentNullException($"{nameof(authors)} is requared");

            Description = description ?? "Without description";
        }
    }
}
