using System;

namespace Domain.Model.Models
{
    public class Claim : Entity
    {
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual DateTime ReservationDate { get; set; } 
        public virtual DateTime CreatedDate { get; protected set; } = DateTime.Now;


        [Obsolete]
        protected Claim() {}

        public Claim(User user, Book book, DateTime reservationDate)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is  null or empty");

            User = user;
            Book = book;
            
            // some logic to obtain from RentDetails.EndDate
            ReservationDate = reservationDate;
        }
    }
}
