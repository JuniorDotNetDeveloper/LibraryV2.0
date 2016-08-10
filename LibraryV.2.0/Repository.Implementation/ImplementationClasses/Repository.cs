using System.Collections;
using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public IEnumerable Collection { get; }


        public void Delete(TEntity entity) 
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }

        public void Save(TEntity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public TEntity GetById(long id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Update(TEntity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
    }
}
