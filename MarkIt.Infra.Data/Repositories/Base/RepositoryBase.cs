using MarkIt.Core.Interfaces.Repositories.Base;
using MarkIt.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MarkIt.Core.Entities.Base;
using MarkIt.Core.Interfaces.DbContext;
using Dapper.Contrib.Extensions;

namespace MarkIt.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, new()
    {        
        protected readonly IDbTransaction _transaction;
        protected readonly IDbConnection _connection;        
        public RepositoryBase(IDbContext context)
        {            
            _transaction = context.UnitOfWork.Transaction;
            _connection = _transaction.Connection;            
        }
        
        public virtual IEnumerable<TEntity> GetAll()
        {            
            return _connection.GetAll<TEntity>(_transaction);
        }
        public TEntity GetById(int id)
        {
            return _connection.Get<TEntity>(id, _transaction);            
        }

        public long Add(TEntity entity)
        {
            return _connection.Insert<TEntity>(entity, _transaction);           
        }
        public bool Remove(TEntity entity)
        {
            return _connection.Delete<TEntity>(entity, _transaction);
        }
        public bool Update(TEntity entity)
        {
            return _connection.Update<TEntity>(entity, _transaction);
        }

        public IQueryable<TEntity> FromSql(string sql, SqlParameter[] parameters)
        {
            return _connection.Query<TEntity>(sql, parameters).AsQueryable();            
        }
    }
}
