﻿using Domain.Model.Models;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public override void Create(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
