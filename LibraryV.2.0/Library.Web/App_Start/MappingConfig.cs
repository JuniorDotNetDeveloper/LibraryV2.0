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
                
                //config.CreateMap<BookViewModel, Book>();
                config.CreateMap<BookCategory, BookCategoryViewModel>();
                config.CreateMap<Author, AuthorViewModel>();
                config.CreateMap<CategoryDto, BookCategoryViewModel>();
                config.CreateMap<User, LogOnViewModel>();
                config.CreateMap<Book, BookViewModel>();
                ;
            });
        }
    }
}