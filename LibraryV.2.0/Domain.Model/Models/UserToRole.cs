namespace Domain.Model.Models
{
    public class UserToRole : Entity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        protected UserToRole() {}
    }
}
