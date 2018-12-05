using Dapper;
using Dapper.Contrib.Extensions;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarkIt.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbContext context) : base(context)
        {           
        }

        public IEnumerable<Product> GetByBarcode(string barcode)
        {
            string procedure = "spr_SelectProductByBarcode";

            var result = _connection.Query<Product>(
                sql: procedure,
                param: new { barcode },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);

            return result;
        }
        public IEnumerable<Product> GetByName(string name)
        {
            string procedure = "SelectProductByName";

            var result = _connection.Query<Product>(
                sql: procedure,
                param: new { name },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);

            return result;
        }
        public IEnumerable<Product> GetRelevantProducts()
        {
            string procedure = "SelectRelevantProducts";

            var result = _connection.Query<Product>(
                sql: procedure,              
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);

            return result;
        }        

    }
}
