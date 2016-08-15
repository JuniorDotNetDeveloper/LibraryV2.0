using System;
using Repository.Abstraction.Interfaces;
using NHibernate;

namespace Repository.Implementation.ImplementationClasses
{
    public class SessionProvider : ISessionProvider
    {
        public ISession _Session { get; }

        public SessionProvider()
        {
            _Session = GetSession();
        }
        public ISession GetSession()
        {
            return SessionGenerator.Instance.GetSession();
        }
    }
}
