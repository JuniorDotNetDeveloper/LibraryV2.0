using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace Library.UnitTest
{
    /// <summary>
    /// Summary description for InMemoryDatabaseForXmlMappings
    /// </summary>
    [TestClass]
    public class InMemoryDatabaseForXmlMappings : IDisposable
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;
        public InMemoryDatabaseForXmlMappings()
        {
            config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "datasource =:memory: ")
                .AddFile("Mappings/Xml/Employee.hbm.xml");

            sessionFactory = config.BuildSessionFactory();
            Session = sessionFactory.OpenSession();

            new SchemaExport(config).Execute(true, true, false, Session.Connection, Console.Out);
        }
        public ISession Session { get; set; }
        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
