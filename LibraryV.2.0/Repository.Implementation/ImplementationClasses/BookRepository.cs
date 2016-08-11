using System.Collections.Generic;
using Domain.Model.Common;
using Domain.Model.Models;
using NHibernate;
using NHibernate.Transform;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class BookRepository : Repository<Book>, IBookRepository
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

        public IList<Book> FindAllBooksByLevel(DeveloperLevel level)
        {
            var books = _session.QueryOver<Book>()
                                   .Where(x => x.FilterLevel == level)
                                   .TransformUsing(Transformers.RootEntity)
                                   .List();

            return books;
        }

        public IList<Book> GetAllBooks()
        {
            var books = _session.QueryOver<Book>().List();
            return books;
        }
    }
}