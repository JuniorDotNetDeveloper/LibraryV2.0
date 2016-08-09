using Domain.Model.Models;

namespace Domaim.Mapping
{
    public class BookCategoryMap : EntityMap<BookCategory>
    {
        public BookCategoryMap()
        {
            Map(x => x.CategoryName).Not.Nullable().UniqueKey("UQ_CategoryName");
            Map(x => x.Description);
        }
    }
}
