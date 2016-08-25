using System;

namespace Domain.Model.Models
{
    public class RatingLog : Entity
    {
        public virtual User User { get; set; }
        public virtual int SectionId { get; set; }
        public virtual int RatingForId { get; set; }
        public virtual int Grade { get; set; }
        public virtual bool Active { get; set; }

        [Obsolete]
        protected RatingLog() { }
    }
}
