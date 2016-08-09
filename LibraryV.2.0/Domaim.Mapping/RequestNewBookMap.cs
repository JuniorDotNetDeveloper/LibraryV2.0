using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class RequestNewBookMap : EntityMap<RequestNewBook>
    {
        public RequestNewBookMap()
        {
            Map(x => x.BookName).Not.Nullable();
            Map(x => x.Motivation).Not.Nullable();
            Map(x => x.RequestDate).Not.Nullable();
            Map(x => x.UrgencyType).Not.Nullable();
            Map(x => x.Link).Not.Nullable();

            References(x => x.User).Not.Nullable();
        }
    }
}
