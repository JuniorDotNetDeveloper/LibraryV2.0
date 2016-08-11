using System.Reflection;
using Domaim.Mapping;
using Domaim.Mapping.Conventions;
using Domain.Model.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repository.Implementation
{
    public class SessionGenerator
    {


        public ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }


        private static ISessionFactory CreateSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
                                                        .Database(MsSqlConfiguration.MsSql2012
                                                                                    .ConnectionString(
                                                                                        builder =>
                                                                                        builder.Database(
                                                                                            "TestDB")
                                                                                               .Server(
                                                                                                   @"MDDSK40046") // DESKTOP-HJ29MGJ
                                                                                               .TrustedConnection()))
                                                        .Mappings(CreateMappingConfiguration)
                                                       .ExposeConfiguration(
                                                            cfg => new SchemaUpdate(cfg).Execute(false, true));


            return configuration.BuildSessionFactory();
        }

        private static void CreateMappingConfiguration(MappingConfiguration mappingConfiguration)
        {
            Assembly assembly = typeof(EntityMap<>).Assembly;
            mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
            mappingConfiguration.HbmMappings.AddFromAssembly(assembly);

            mappingConfiguration.AutoMappings.Add(AutoMap.AssemblyOf<Entity>()
                .Override<User>(u =>
                {
                    u.Id(x => x.Id).Column("UID");
                    CustomForeignKeyConvention.Mappings.Add(u);
                }
                ));

        }


        private SessionGenerator()
        {
        }

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

    }
}
