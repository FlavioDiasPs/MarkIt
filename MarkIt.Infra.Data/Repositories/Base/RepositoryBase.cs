using MarkIt.Core.Interfaces.Repositories.Base;
using MarkIt.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace MarkIt.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {      
        protected readonly IDbTransaction transaction;
        protected readonly IDbConnection connection; 
        public RepositoryBase(IDbContext context)
        {            
            transaction = context.UnitOfWork.Transaction;
            connection = transaction.Connection;
        }

        public void Add(TEntity obj)
        {
            string sql = "insert into Product values(@name, @description)";
            connection.Execute(sql, new { obj }, transaction: transaction);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            //connection.QuerySingleOrDefault<IEnumerable<Product>>("select * from dbo.Product", transaction: transaction);
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
        public IQueryable<TEntity> FromSql(object obj, string sql, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
            //return _context.Repository.FromSql(obj, sql, parameters).AsQueryable<TEntity>;
        }
    }
}
