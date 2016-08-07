using System;

namespace Domain.Model.Models
{
    public class Comment : Entity
    {
        public virtual long UserId { get; set; }
        public virtual long BookId { get; set; }
        public virtual string Commentary{ get; set; }
        public virtual DateTime CommetDate { get; } = DateTime.Now;

        protected Comment()  { }

        public Comment(long userId, long bookId, string commentary)
        {
            if (userId == 0)
                throw new ArgumentException("UserId can not be 0");
            if (bookId == 0)
                throw new ArgumentException("BookId can not be 0");
            if (string.IsNullOrWhiteSpace(commentary))
                throw new ArgumentException("Comment can't be null or whiteSpace");
            UserId = userId;
            BookId = bookId;
            Commentary = commentary;
        }
    }
}
