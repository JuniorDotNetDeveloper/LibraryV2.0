using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        /*
                select  b.Name as BookName, a.FirstName, a.LastName, b.CategoryName
	                from Author a, Book b
	                where a.Id = (select bta.AuthorId from BookToAuthor bta
					where bta.BookId = b.Id)
        */
        
    }
}
