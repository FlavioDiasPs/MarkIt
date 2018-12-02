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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {        
        public ProductRepository(IDbContext context) : base(context)
        {            
        }

        public void AddProduct(Product obj)
        {
            string sql = "insert into Product values(@name, @description)";
            string preco = Convert.ToString(obj.Price.Valor);

            connection.Execute(sql, new { obj.Name, preco }, transaction: transaction);
        }

        public IEnumerable<Product> QuerySomething()
        {            
            return connection.QuerySingleOrDefault<IEnumerable<Product>>("select * from dbo.Product", transaction: transaction);
        }

        public IQueryable<Product> GetProductsFromMarket()
        {
            throw new NotImplementedException();
        }
    }
}
