using System;

namespace Domain.Model.Models
{
    public class RentBookDetails : Entity
    {
        public virtual RentBook RentBook { get; protected set; }
        public virtual Book Book { get; protected set; }
        public virtual DateTime EndDate { get; protected set; }
        public virtual int ExtendCount { get; protected set; }
        public virtual int DelayCount { get; protected set; }

        [Obsolete]
        protected RentBookDetails() {}

        public RentBookDetails(RentBook rentBook, Book book)
        {
            if (book == null) throw new ArgumentNullException($"{nameof(book)} is null");
            if (rentBook == null) throw new ArgumentNullException($"{nameof(rentBook)} is null");

            RentBook = rentBook;
            Book = book;
            EndDate = RentBook.RentDate.AddDays(21);
        }
    }
}
