using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MarkIt.Core.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);        
        void Update(TEntity obj);
        void Remove(TEntity obj);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
