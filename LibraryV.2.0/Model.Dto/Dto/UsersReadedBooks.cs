using Domain.Model.Models;

namespace Domain.Model.Dto
{
    public class UsersReadedBooks
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookCount { get; set; }
    }
}
