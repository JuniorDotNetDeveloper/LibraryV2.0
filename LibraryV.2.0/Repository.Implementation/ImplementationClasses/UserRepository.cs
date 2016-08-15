using System;
using System.Collections.Generic;
using Domain.Model.Models;
using Repository.Abstraction.Interfaces;
using NHibernate.Criterion;
using NHibernate.Transform;
using Domain.Model.Dto;
using NHibernate;

namespace Repository.Implementation.ImplementationClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public IList<UsersReadedBooks> GetAllReadedBooks()
        {
            /*
                    select u.Id, u.FirstName, u.LastName,
		                ( 
			                Select count(od.BookId) from OrderDetails od
			                inner join [Order] o on od.OrderId = o.Id
			                where u.Id = o.UserId
		                ) as 'Total Books'

	                from [User] u
	                Order by 'Total Books' desc
             */
            UsersReadedBooks usersReadedAllias = null;
            RentBook rentAlias = null;
            RentBookDetails rentBookDetailsAllias = null;
            User userAlias = null;

            //var allReadedBooks = QueryOver.Of(() => rentAlias)
            //    .JoinAlias(() => rentAlias.RentDetails, () => rentBookDetailsAllias)
            //    .JoinAlias(() => rentAlias.User, () => userAlias);
            //    //.Where(() => rentAlias.User.Id == userAlias.Id);

            //var usersWithBooks = _session.QueryOver(() => rentAlias)
            //    .JoinAlias(() => rentAlias.User, () => userAlias)

            //    .JoinQueryOver(() => rentAlias.RentDetails, () => rentBookDetailsAllias)
            //    .WithSubquery.WhereProperty(x => x.Book).In(allReadedBooks)
            //    .SelectList(list => list
            //        .Select(u => u.User.FirstName).WithAlias(() => usersReadedAllias.userName)
            //        .Select(() => userAlias).WithAlias(() => usersReadedAllias.bookName));

            //return usersWithBooks.List<UsersReadedBooks>();

            var usersWithBooks = _session.QueryOver<RentBookDetails>()
                .JoinQueryOver(x => x.RentBook, () => rentAlias)
                .JoinQueryOver(() => rentAlias.User, () => userAlias)

                    .SelectList(x => x
                        .SelectGroup(u => userAlias.FirstName).WithAlias(() => usersReadedAllias.FirstName)
                        .SelectGroup(u => userAlias.LastName).WithAlias(() => usersReadedAllias.LastName)
                        .SelectCount(c => rentAlias.Id).WithAlias(() => usersReadedAllias.BookCount)

                )
                .TransformUsing(Transformers.AliasToBean<UsersReadedBooks>());

            return usersWithBooks.List<UsersReadedBooks>();
        }

        public IList<Book> GetCurrentBooks(long userId)
        {
            Book book= null;
            RentBook rentBook = null;

            var currentBooks =  _session.QueryOver<RentBookDetails>()
                .JoinAlias(x=>x.RentBook, () => rentBook)
                .Where(x => x.EndDate > DateTime.Now && rentBook.User.Id == userId)
                .Select(Projections.Conditional(Restrictions.Where(() => book.Id > 0),
                                                Projections.Constant("", NHibernateUtil.String),
                                                Projections.Constant("", NHibernateUtil.String)))
                .List<Book>();

            return currentBooks;


            /*
                         string query = @"select b.Name from [Book] b
                            join [RentBookDetails] od on b.Id = od.BookId
                            join [RentBook] o on od.OrderId = o.Id
	                        where od.EndDate > Getdate() and o.UserId = Id";
            */
        }


    }
}
