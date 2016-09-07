using System.Collections.Generic;

namespace Library.Web.Models
{
    public class AuthorViewModel
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        //public IList<BookViewModel> PersonalBooks { get; } = new List<BookViewModel>();
    }
}