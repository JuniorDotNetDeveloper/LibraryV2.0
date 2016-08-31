using Domain.Model.Models;
using Library.Web.Models;

namespace Library.Web.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Book, BookDetailsViewModel>();
                config.CreateMap<Author, AuthorViewModel>();
                config.CreateMap<BookCategory, BookCategoryViewModel>();
            });
        }
    }
}