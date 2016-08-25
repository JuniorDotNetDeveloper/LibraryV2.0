using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class RatingLogMap : EntityMap<RatingLog>
    {
        public RatingLogMap()
        {
            /*      User User { get; set; }
                    int RatingForId { get; set; }
                    int Grade { get; set; }
                    bool Active { get; set; }
            */

            References(x => x.User);
            Map(x => x.SectionId);
            Map(x => x.Grade);
            Map(x => x.RatingForId);
            Map(x => x.Active);

        }
    }
}
