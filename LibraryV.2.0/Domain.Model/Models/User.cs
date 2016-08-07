using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class User : Entity
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual int TelephoneNumber { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual IList<Book> CurrentBooks { get; } = new List<Book>();

        public User(string firstName, string lastName, string password, string email, int telephoneNumner = 0)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException($"{nameof(firstName)} is null or empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException($"{nameof(lastName)} is null or empty");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException($"{nameof(email)} is null or empty");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException($"{nameof(password)} is null or empty");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            TelephoneNumber = telephoneNumner;
        }

        protected User() { }

        public virtual void TakeTheBook(Book book)
        {
           throw  new NotImplementedException();
        }
    }
}
