using System;
using System.Collections.Generic;
using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public IList<Book> GetCurrentBooks()
        {
            RentBookDetails rentBookDetails = null;
            RentBook rentBook = null;

            var currentBooks =  _session.QueryOver<Book>()
                .JoinQueryOver(() => rentBookDetails.Book)
                .JoinQueryOver(() => rentBook)
                .Where(()=>rentBookDetails.EndDate > DateTime.Now).List();
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
