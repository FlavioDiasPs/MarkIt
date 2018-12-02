using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using System;
using System.Linq;

namespace MarkIt.Infra.Data.Repositories
{
    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {        
        public MarketRepository(IDbContext context) : base(context)
        {            
        }       
    }
}
