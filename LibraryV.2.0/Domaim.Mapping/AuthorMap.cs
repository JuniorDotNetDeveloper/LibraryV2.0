using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class AuthorMap : EntityMap<Author>
    {
        protected AuthorMap()
        {
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
           
            //Map(x => x.PersonalBooks).Formula(@"select * from [book] b join [AuthorToBook] ab on b.Id = ab.BookId where ab.AuthorId = Id");
        }
    }
}
