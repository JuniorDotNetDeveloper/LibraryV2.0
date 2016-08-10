using System;
using System.Collections.Generic;
using Domain.Model.Common;

namespace Domain.Model.Models
{
    public class Book : Entity 
    {
        public virtual string Name { get; protected set; }
        public virtual DateTime PublicationDate { get; protected set; }
        public virtual BookCategory Category { get; protected set; }
        public virtual string Description { get; set; }
        public virtual BookStatus Status { get; set; } = BookStatus.Free;
        public virtual DeveloperLevel FilterLevel { get; set; } = DeveloperLevel.Beginner;
        public virtual int? Rating { get; set; }
        public virtual IList<AuthorToBook> Authors { get; protected set; }
        public virtual IList<BookToTags> Tags { get; set; }
        public virtual IList<Comment> Comments { get; }
       

        [Obsolete]
        protected Book() { }

        #region constructors must be refacored because of temporaly insertion information
        public Book(string bookName, DateTime publicationDate,  string description, IList<AuthorToBook> authors)
          
        {
            ValidateInput(bookName, publicationDate, description, authors);

            Authors = authors;
            Name = bookName;
            PublicationDate = publicationDate;
        }

        public Book(string bookName, DateTime publicationDate, string description = null, AuthorToBook author = null)
            : this( bookName, publicationDate, description, new List<AuthorToBook> { author })
        {
            
        }

        public Book(string bookName, DateTime publicationDate, BookCategory category, string description = null, AuthorToBook author = null)
            : this( bookName, publicationDate, description, new List<AuthorToBook> { author })
        {
            Category = category;
        }
        #endregion

        private void ValidateInput( string bookName, DateTime publicationDate, string description, IList<AuthorToBook> authors = null)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentNullException($"Next field named: {nameof(bookName)} is null or empty");
            if (publicationDate == null)
                throw new ArgumentNullException($"{nameof(publicationDate)} is requared");
            //if (authors == null) throw new ArgumentNullException($"{nameof(authors)} is requared");

            Description = description ?? "Without description";
        }
    }
}
