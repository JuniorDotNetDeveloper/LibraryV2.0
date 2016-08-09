using System;
using System.Collections.Generic;
using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        //public IList<Book> GetCurrentBooks()
        //{
        //    OrderDetails od = null;
        //    Order o = null;
        //    _session.QueryOver<Book>()
        //        .JoinAlias(b=>b.Id, () => od.Book.Id)


        //    string query = @"select b.Name from [Book] b
        //                    join [OrderDetails] od on b.Id = od.BookId
        //                    join [Order] o on od.OrderId = o.Id
	       //                 where od.EndDate > Getdate() and o.UserId = Id";
        //}
        public IList<Book> GetCurrentBooks()
        {
            OrderDetails orderDetails = null;
            Order order = null;

            var currentBooks =  _session.QueryOver<Book>()
                .JoinQueryOver(() => orderDetails.Book.Id)
                .JoinQueryOver(() => order.Id)
                .Where(()=>orderDetails.EndDate > DateTime.Now).List();
            return currentBooks;
        }

        public override void Create(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
