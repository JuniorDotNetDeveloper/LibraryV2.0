using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class CommentMap : EntityMap<Comment>
    {
        public CommentMap()
        {
            Map(x => x.CommetDate).Not.Nullable().ReadOnly();
            Map(x => x.Commentary).Not.Nullable();

            References(x => x.Book).Not.Nullable().ForeignKey("FK_Comment_Books");
            References(x => x.User).Not.Nullable().ForeignKey("FK_Comment_Users");
        }
    }
}
