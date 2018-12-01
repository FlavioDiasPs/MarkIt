using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Repositories.Base;
using MarkIt.Infra.Data.Repositories.Base;
using MarkIt.Infra.Data.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.Transactions
{
    public interface IDbContext<TEntity> where TEntity : class
    {
        UnitOfWork UnitOfWork { get; }        
        IRepositoryBase<TEntity> Repository{ get; }

        void Commit();
        void Rollback();
    }
}
