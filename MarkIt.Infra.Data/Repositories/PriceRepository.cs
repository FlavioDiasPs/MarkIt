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
        
        public IEnumerable<Price> GetPricesByProductBarCode(string productBarCode)
        {
            string procedure = "SelectProductByBarCode";            

            var result = _connection.Query<Price, int, int, Price>(
                sql:procedure, 
                param:new { productBarCode }, 
                transaction:_transaction, 
                commandType: CommandType.StoredProcedure, 
                map:(price, product, market) => {
                    price.Product = new Product() { Id = product, Barcode = productBarCode };
                    price.Market = new Market() { Id = market };
                    return price;
                }, splitOn: "Id, ProductId, MarketId");

            return result;
        }

        public IEnumerable<Price> GetPricesByProductId(int productid)
        {
            string procedure = "SelectDetailsById";

            var result = _connection.Query<Price, Market, Price>(
              sql: procedure,
              param: new { productid },
              transaction: _transaction,
              commandType: CommandType.StoredProcedure,
              map: (price, market) => {
                  price.Market = new Market() { Id = market.Id, Name = market.Name, Latitude = market.Latitude, Longitude = market.Longitude };
                  return price;
              });

            return result;
        }
    }
}
