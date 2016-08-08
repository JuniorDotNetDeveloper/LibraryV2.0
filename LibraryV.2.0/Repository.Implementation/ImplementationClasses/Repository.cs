using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public IEnumerable Collection { get; }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity) 
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public TEntity GetById(int id)
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
