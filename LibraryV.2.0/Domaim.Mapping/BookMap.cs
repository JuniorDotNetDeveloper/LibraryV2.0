namespace Domaim.Mapping
{
    using Domain.Model.Models;

    public class BookMap : EntityMap<Book>
    {
        protected BookMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.PublicationDate).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.Rating);
            Map(x => x.Status).Not.Nullable();
            Map(x => x.FilterLevel).Not.Nullable();

            //HasMany(x => x.Authors).Inverse();

            References(x => x.Category).Not.Nullable().ForeignKey("FK_Book_Categories");
            HasMany(x => x.Comments).Inverse();
            HasMany(x => x.Tags).Inverse();

            CheckConstraint(@"[Status] = 'Free' OR [Status] = 'Busy'");
        }
    }
}
