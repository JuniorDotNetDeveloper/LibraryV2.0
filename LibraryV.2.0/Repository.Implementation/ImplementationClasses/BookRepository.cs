﻿using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    internal class BookRepository : Repository, IBookRepository
    {
        public void ModifyBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewBook(Book book)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(book);
                transaction.Commit();
            }
        }
    }
}