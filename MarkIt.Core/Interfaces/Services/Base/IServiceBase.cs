using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MarkIt.Core.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        long Add(TEntity obj);
        bool Update(TEntity obj);
        bool Remove(TEntity obj);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
