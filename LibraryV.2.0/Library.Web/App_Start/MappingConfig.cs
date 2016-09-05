using Domain.Model.Models;
using Library.Web.Models;
using Model.Dto.Dto;

namespace Library.Web.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Book, BookDetailsViewModel>();
                config.CreateMap<BookDetailsViewModel, Book>();
                config.CreateMap<BookCategory, BookCategoryViewModel>();
                config.CreateMap<Author, AuthorViewModel>();
                config.CreateMap<CategoryDto, BookCategoryViewModel>();
            });
        }
    }
}