using Domain.Model.Models;
using System.Collections.Generic;

namespace Repository.Abstraction.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> Collection { get; }
        void Create<TEntity>(TEntity entity) ;
        void Update<TEntity>(TEntity entity);
        void Delete<TEntity>(TEntity entity);
        void Save<TEntity>(TEntity entity);
        TEntity FindById(int id);
    }
}
