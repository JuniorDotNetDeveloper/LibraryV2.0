using Domain.Model.Models;
using System.Collections.Generic;
using Model.Dto.Dto;

namespace Repository.Abstraction.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void MakeDetached(Author author);
        IList<AuthorsAndCategoriesDto> GetAuthorsWithSpecifyCategory(string category);
    }
}
