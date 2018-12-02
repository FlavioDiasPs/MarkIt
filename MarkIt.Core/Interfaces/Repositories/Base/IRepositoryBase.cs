using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using MarkIt.Core.Entities.Base;

namespace MarkIt.Core.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase, new()
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();     
        IQueryable<TEntity> FromSql(string sql, SqlParameter[] parameters);
    }
}
