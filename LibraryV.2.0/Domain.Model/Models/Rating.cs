namespace Domain.Model.Models
{
    public class Rating : Entity
    {
        private const int _MAXRATINGVALUE = 5;
        private const int _MINRATINGVALUE = 1;

        public virtual long BookId { get; set; }
        public virtual float RatingValue { get; set; }
    }
}
