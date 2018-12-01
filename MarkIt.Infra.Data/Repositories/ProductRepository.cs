using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace MarkIt.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IDbConnection connection;
        protected readonly IDbTransaction transaction;

        public ProductRepository(UnitOfWork unitOfWork)
        {
            connection = unitOfWork.Transaction.Connection;
            transaction = unitOfWork.Transaction;
        }    

        public void Add(Product obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> FromSql(object obj, string sql, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return connection.QuerySingleOrDefault<IEnumerable<Product>>("select * from dbo.Product", transaction: transaction);
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProductsFromMarket()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Queryable()
        {
            throw new NotImplementedException();
        }        

        public void Remove(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
