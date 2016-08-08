using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class CommentMap : EntityMap<Comment>
    {
        public CommentMap()
        {
            Map(x => x.CommetDate).Not.Nullable().ReadOnly();
            Map(x => x.Commentary).Not.Nullable();

            Map(x => x.BookId).Not.Nullable();
            Map(x => x.UserId).Not.Nullable();
        }
    }
}
