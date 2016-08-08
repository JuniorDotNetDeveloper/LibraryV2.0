using System;

namespace Domain.Model.Models
{
    public class AuthorToBook : Entity
    {
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }

        [Obsolete]
        protected AuthorToBook() { }
    }
}
