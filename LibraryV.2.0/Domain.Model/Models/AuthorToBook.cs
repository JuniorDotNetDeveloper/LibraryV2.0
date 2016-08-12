using System;

namespace Domain.Model.Models
{
    public class AuthorToBook : Entity
    {
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }

        [Obsolete]
        protected AuthorToBook() { }

        public AuthorToBook(Book book, Author author)
        {
            if (book == null)
                throw new ArgumentNullException($"{book} is null");
            if (author == null)
                throw new ArgumentNullException($"{author} is null");
            Book = book;
            Author = author;
        }

        //public AuthorToBook(Book book, int authorId)
        //{
        //    if (book == null)
        //        throw new ArgumentNullException();
        //    Book = book;
        //    Author.Id = authorId;
        //}
    }
}
