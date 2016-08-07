using System;

namespace Domain.Model.Models
{
    public class RequestNewBook : Entity
    {
        public long UserId { get; set; }
        public virtual DateTime RequestDate { get; } = DateTime.Now;
        public virtual string BookName { get; protected set; }
        public virtual string Motivation { get; set; }


        protected RequestNewBook() { }

        public RequestNewBook(long userId, string bookName, string motivation )
        {
            if (userId == 0)
                throw new ArgumentException("UserId can't be 0");
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentException("BookName can't be null or whiteSpace");
            if (string.IsNullOrWhiteSpace(motivation))
                throw new ArgumentException("Comment can't be null or whiteSpace");

            UserId = userId;
            BookName = bookName;
            Motivation = motivation;
        }
    }
}
