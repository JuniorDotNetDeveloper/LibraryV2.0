using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> Collection { get; }
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save(TEntity entity);
        TEntity FindById(int id);
    }
}
