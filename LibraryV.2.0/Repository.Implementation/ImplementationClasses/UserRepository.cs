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
    }
}
