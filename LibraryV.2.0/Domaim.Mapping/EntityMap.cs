using Domain.Model.Models;
using FluentNHibernate.Mapping;

namespace Domaim.Mapping
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        protected EntityMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            DynamicUpdate();
        }
    }
}
