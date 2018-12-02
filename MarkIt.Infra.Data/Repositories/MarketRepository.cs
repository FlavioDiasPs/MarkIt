using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.DapperConfig;
using MarkIt.Infra.Data.Repositories.Base;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace MarkIt.Infra.Data.Repositories
{
    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {        
        public MarketRepository(IDbContext context) : base(context)
        {            
        }

        public void AddMarket(Market obj)
        {
            Add(obj);
        }

        public IQueryable<Market> GetClosestMarkets(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }
    }
}
