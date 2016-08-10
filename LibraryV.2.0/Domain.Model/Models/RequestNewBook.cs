using System;
using Domain.Model.Common;

namespace Domain.Model.Models
{
    public class RequestNewBook : Entity
    {
        public virtual User User { get; set; }
        public virtual DateTime RequestDate { get; } = DateTime.Now;
        public virtual string BookName { get; protected set; }
        public virtual DateTime? BookPublicationDate { get; protected set; }
        public virtual string Motivation { get; set; }
        public virtual string Link { get; set; }
        public virtual Urgency UrgencyType { get; set; } = Urgency.WouldBeNice;

        [Obsolete]
        protected RequestNewBook() { }

        public RequestNewBook(User userId, string bookName, string motivation, Urgency urgency, string link, DateTime? bookPublicationDate = null )
        {
            if (userId == null)
                throw new ArgumentException("UserId can't be 0");
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentException($"{nameof(bookName)} is null or whiteSpace");
            if (string.IsNullOrWhiteSpace(motivation))
                throw new ArgumentException($"{nameof(motivation)} is null or whiteSpace");
            if (string.IsNullOrWhiteSpace(link))
                throw new ArgumentException($"{nameof(link)} is null or whiteSpace");

            User = userId;
            BookName = bookName;
            Motivation = motivation;
            UrgencyType = urgency;
            Link = link;
            BookPublicationDate = bookPublicationDate;
        }
    }
}
