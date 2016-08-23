namespace Domaim.Mapping
{
    using Domain.Model.Models;

    public class BookMap : EntityMap<Book>
    {
        protected BookMap()
        {
            Map(x => x.Name).UniqueKey("UQ_Book").Not.Nullable();
            Map(x => x.PublicationDate).Not.Nullable();
            Map(x => x.Description).Length(1000);
            Map(x => x.BookCover);
            Map(x => x.Rating);
            Map(x => x.Status).Not.Nullable();
            Map(x => x.FilterLevel).Not.Nullable();

            HasMany(x => x.Authors).Cascade.All().Inverse().ForeignKeyCascadeOnDelete();

            References(x => x.Category).Not.Nullable().ForeignKey("FK_Book_Categories");
            HasMany(x => x.Comments).Inverse();
            HasMany(x => x.Tags).Cascade.SaveUpdate().Inverse();

            CheckConstraint(@"[Status] = 'Free' OR [Status] = 'Busy'");
        }
    }
}
