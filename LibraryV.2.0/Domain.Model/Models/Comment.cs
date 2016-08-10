using System;

namespace Domain.Model.Models
{
    public class Comment : Entity
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual string Commentary{ get; set; }
        public virtual DateTime CommetDate { get; } = DateTime.Now;

        [Obsolete]
        protected Comment()  { }

        public Comment(User user, Book book, string commentary)
        {
            if (user == null)
                throw new ArgumentException("UserId can not be 0");
            if (book == null)
                throw new ArgumentException("BookId can not be 0");
            if (string.IsNullOrWhiteSpace(commentary))
                throw new ArgumentException("Comment can't be null or whiteSpace");
            User = user;
            Book = book;
            Commentary = commentary;
        }
    }
}
