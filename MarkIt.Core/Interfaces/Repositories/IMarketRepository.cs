using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories.Base;
using System.Linq;

namespace MarkIt.Core.Interfaces.Repositories
{
    public interface IMarketRepository : IRepositoryBase<Market>
    {
        IQueryable<Market> GetClosestMarkets(string latitude, string longitude);
    }    
}
