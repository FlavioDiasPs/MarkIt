using MarkIt.Core.Interfaces.Repositories.Base;
using MarkIt.Infra.Data.DapperConfig;
using MarkIt.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MarkIt.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly IDbContext<TEntity> _context;
        public RepositoryBase(IDbContext<TEntity> context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Repository.Add(obj);
            _context.Commit();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _context.Repository.GetById(id);
        }
        public IQueryable<TEntity> Queryable()
        {
            return _context.Repository.Queryable();
        }

        public void Remove(TEntity obj)
        {
            _context.Repository.Remove(obj);
            _context.Commit();
        }

        public void Update(TEntity obj)
        {
            _context.Repository.Update(obj);
            _context.Commit();
        }
        public IQueryable<TEntity> FromSql(object obj, string sql, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
            //return _context.Repository.FromSql(obj, sql, parameters).AsQueryable<TEntity>;
        }
    }
}
