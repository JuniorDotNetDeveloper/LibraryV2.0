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
        public virtual IList<AuthorToBook> Authors { get; protected set; } = new List<AuthorToBook>();
        public virtual IList<BookToTags> Tags { get; set; }
        public virtual IList<Comment> Comments { get; }
        

        [Obsolete]
        protected Book() { }
               
        public Book(string bookName, DateTime publicationDate, BookCategory category, IList<Author> authors, string description = null)   
        {
            ValidateInput(bookName, publicationDate, category, description, authors);
            foreach (var author in authors)
            {
                var authorToBook = new AuthorToBook(this, author);
                Authors.Add(authorToBook);
            }
            Category = category;
            Name = bookName;
            PublicationDate = publicationDate;
        }

        private void ValidateInput( string bookName, DateTime publicationDate, BookCategory category, string description, IList<Author> authors = null)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentNullException($"Next field named: {nameof(bookName)} is null or empty");
            if (publicationDate == null)
                throw new ArgumentNullException($"{nameof(publicationDate)} is requared");
            if (authors == null) throw new ArgumentNullException($"{nameof(authors)} is requared");
            if (category == null) throw new ArgumentNullException($"{nameof(category)} is requared");

            Description = description ?? "Without description";
        }
    }
}
