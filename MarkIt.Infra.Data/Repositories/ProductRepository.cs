using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.DapperConfig;
using MarkIt.Infra.Data.Repositories.Base;
using MarkIt.Infra.Data.Transactions;
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
        protected readonly IDbContext<Product> _context;

        public ProductRepository(IDbContext<Product> context) : base(context)
        {
            _context = context;
        }

        public void AddProduct(Product obj)
        {
            Add(obj);
        }

        public IEnumerable<Product> QuerySomething()
        {
            var transaction = _context.UnitOfWork.Transaction;
            var conn = transaction.Connection;
            
            return conn.QuerySingleOrDefault<IEnumerable<Product>>("select * from dbo.Product", transaction: transaction);
        }         

        public IQueryable<Product> GetProductsFromMarket()
        {
            throw new NotImplementedException();
        }
    }
}
