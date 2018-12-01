using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly StackOverflowContext _context;
        public RepositoryBase(StackOverflowContext context)
        {
            _context = context;
        }
        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> Queryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IQueryable<TEntity> FromSql(object obj, string sql, SqlParameter[] parameters)
        {
            return _context.Set<TEntity>().FromSql(sql, parameters).AsQueryable();
        }
    }
