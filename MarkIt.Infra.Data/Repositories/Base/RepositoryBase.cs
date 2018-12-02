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

namespace MarkIt.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly string _tableName;
        protected readonly IDbTransaction _transaction;
        protected readonly IDbConnection _connection;        
        public RepositoryBase(IDbContext context)
        {
            _tableName = new TEntity().GetType().Name;
            _transaction = context.UnitOfWork.Transaction;
            _connection = _transaction.Connection;            
        }

        public void Add(TEntity entity)
        {           
            string sql = $"insert into {_tableName} values({entity.ToString()})";
            _connection.Execute(sql, new { entity }, transaction: _transaction);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            string sql = $"select * from {_tableName}";
            return _connection.Query<TEntity>(sql, transaction: _transaction);
        }

        public TEntity GetById(int id)
        {
            string sql = $"select * from {_tableName} where id = {id}";
            var result = _connection.QueryFirstOrDefault<TEntity>(sql, transaction: _transaction);


            return result;
        }      

        public void Remove(TEntity entity)
        {
            string sql = $"delete from {_tableName} where id = {entity.Id}";
            _connection.Execute(sql, transaction: _transaction);
        }

        public void Update(TEntity entity)
        {
            //string sql = $"update {_tableName} set @id = {entity.Id}";
            //_connection.Execute(sql, transaction: _transaction);

            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FromSql(string sql, SqlParameter[] parameters)
        {
            return _connection.Query<TEntity>(sql, parameters).AsQueryable();            
        }
    }
}
