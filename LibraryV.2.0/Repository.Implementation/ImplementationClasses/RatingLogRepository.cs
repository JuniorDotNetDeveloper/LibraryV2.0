using Domain.Model.Models;
using Repository.Abstraction.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation.ImplementationClasses
{
    public class RatingLogRepository : Repository<RatingLog>, IRatingLogRepository
    {
        public RatingLogRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
