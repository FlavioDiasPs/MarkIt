using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkIt.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {        
        public ProductRepository(IDbContext context) : base(context)
        {            
        }

        //public void AddProduct(Product obj)
        //{            
        //    string sql = "insert into Product values(@name, @description)";
        //    string description = Convert.ToString(55);

        //    _connection.Execute(sql, new { obj.Name, description }, transaction: _transaction);
        //}

        public IEnumerable<Product> QuerySomething()
        {            
            return _connection.QuerySingleOrDefault<IEnumerable<Product>>("select * from dbo.Product", transaction: _transaction);
        }

        public IQueryable<Product> GetProductsFromMarket()
        {
            throw new NotImplementedException();
        }
    }
}
