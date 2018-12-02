using Dapper;
using Dapper.Contrib.Extensions;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Data;

namespace MarkIt.Infra.Data.Repositories
{
    public class PriceRepository : RepositoryBase<Price>, IPriceRepository
    {
        public PriceRepository(IDbContext context) : base(context)
        {
        }

        public long AddNewPrice(Price price)
        {
            return _connection.Insert<Price>(price);
        }

        public IEnumerable<Price> GetPricesByProductId(int productId)
        {
            string procedure = "SelectProductById";
            //return _connection.Query<Price>(procedure, new { productId }, _transaction, commandType: CommandType.StoredProcedure);

            var result = _connection.Query<Price, int, int, Price>(
                sql:procedure, 
                param:new { productId }, 
                transaction:_transaction, 
                commandType: CommandType.StoredProcedure, 
                map:(price, product, market) => {
                    price.Product = new Product() { Id = product };
                    price.Market = new Market() { Id = product };
                    return price;
                }, splitOn: "Id, ProductId, MarketId");

            return result;
        }

        public IEnumerable<Price> QuerySomething()
        {
            return _connection.QuerySingleOrDefault<IEnumerable<Price>>("select * from dbo.Product", transaction: _transaction);
        }
    }
}
