using System.Collections;
using Domain.Model.Models;
using System.Collections.Generic;

namespace Repository.Abstraction.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable Collection { get; }
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save(TEntity entity);
        TEntity GetById(int id);
    }
}
