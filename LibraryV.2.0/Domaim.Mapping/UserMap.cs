using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.TelephoneNumber);

            Map(x => x.CurrentBooks).Formula(@"select b.Name from [Book] b 
                                                join [OrderDetails] od on b.Id = od.BookId 
                                                join [Order] o on od.OrderId = o.Id 
                                                where od.EndDate > Getdate() and o.UserId = Id");
        }
    }
}
