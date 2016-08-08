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
            Map(x => x.Status).Not.Nullable();
            Map(x => x.Rating);

            HasMany(x => x.Comments).AsList().Inverse();
            HasMany(x => x.Tags).Inverse().AsSet();
        }
    }
}
