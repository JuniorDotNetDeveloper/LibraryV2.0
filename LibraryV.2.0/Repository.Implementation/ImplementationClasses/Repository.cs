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
        protected readonly ISession _session;

        public Repository(ISessionProvider sessionProvider)
        {
            _session = sessionProvider._Session;
        }

        public IList<TEntity> Collection => _session.QueryOver<TEntity>().List<TEntity>();

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

