﻿using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class Author : Entity
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual IList<AuthorToBook> PersonalBooks { get; } = new List<AuthorToBook>();

        [Obsolete]
        protected Author() { }
        public Author(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException($"{nameof(firstName)} is null or empty");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException($"{nameof(lastName)} is null or empty");
            
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void AddNewBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException($"{nameof(book)} is null");
            var newBook = new AuthorToBook(book, this);
            PersonalBooks.Add(newBook);
        }
    }
}
