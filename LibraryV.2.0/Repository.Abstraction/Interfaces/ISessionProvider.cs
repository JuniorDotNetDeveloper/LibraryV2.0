using NHibernate;

namespace Repository.Abstraction.Interfaces
{
    public interface ISessionProvider
    {
       ISession _Session { get; }
    }
}
