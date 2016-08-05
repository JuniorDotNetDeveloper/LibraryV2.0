using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class User : Entity
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual int TelefonNumber { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual IList<Book> CurrentBooks { get; } = new List<Book>();

        public User(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException($"{nameof(firstName)} is null or empty");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException($"{nameof(lastName)} is null or empty");

            FirstName = firstName;
            LastName = lastName;
        }

        protected User() { }

        public virtual void TakeTheBook(Book book)
        {
           throw  new NotImplementedException();
        }
    }
}
