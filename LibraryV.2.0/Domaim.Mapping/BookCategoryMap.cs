using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class BookCategoryMap : EntityMap<BookCategory>
    {
        public BookCategoryMap()
        {
            Map(x => x.CategoryName).Not.Nullable().Unique();
            Map(x => x.Description);
        }
    }
}
