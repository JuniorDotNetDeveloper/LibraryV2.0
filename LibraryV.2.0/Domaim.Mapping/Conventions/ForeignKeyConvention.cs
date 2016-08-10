using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.MappingModel.Identity;

namespace Domaim.Mapping.Conventions
{
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
      
        public static IList<IMappingProvider> Mappings = new List<IMappingProvider>();

        protected override string GetKeyName(Member property, Type type)
        {
            var pk = "Id";

            var model = new PersistenceModel();
            foreach (var map in Mappings)
            {
                model.Add(map);
            }

            try
            {
                var mymodel = (IdMapping)model.BuildMappings()
                    .First(x => x.Classes.FirstOrDefault(c => c.Type == type) != null)
                    .Classes.First().Id;

                Func<IdMapping, string> getname = x => x.Columns.First().Name;
                pk = getname(mymodel);
            }
            catch
            {
            }

            if (property == null)
            {
                return type.Name + pk;
            }
            return type.Name + property.Name;
        }
    }
}
