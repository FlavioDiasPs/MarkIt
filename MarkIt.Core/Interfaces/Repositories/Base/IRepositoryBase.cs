﻿using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace MarkIt.Core.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Queryable();        
        IQueryable<TEntity> FromSql(object obj, string sql, SqlParameter[] parameters);
    }
}