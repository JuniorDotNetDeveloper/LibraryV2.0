using Domain.Model.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaim.Mapping
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        #region Non-public members

        protected EntityMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("1000");

            DynamicUpdate();
        }

        #endregion
    }
}
