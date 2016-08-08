using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Model.Models;
using NHibernate;
using Repository.Abstraction.Interfaces;

namespace Repository.Implementation.ImplementationClasses
{
    public abstract class Repository : IRepository<Entity>
    {
        protected readonly ISession _session = SessionGenerator.Instance.GetSession();

        public IEnumerable Collection { get; }

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entity entity) 
        {
            throw new NotImplementedException();
        }

        public void Save(Entity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public Entity GetById(int id)
        {
            return _session.Get<Entity>(id);
        }

        public void Update(Entity entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
    }
}
