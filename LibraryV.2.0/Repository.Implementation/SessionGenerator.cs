using System.Reflection;
using Domaim.Mapping;
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
                                                                                                   @"MDDSK40046")
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

        }


        private SessionGenerator()
        {
        }

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

    }
}
