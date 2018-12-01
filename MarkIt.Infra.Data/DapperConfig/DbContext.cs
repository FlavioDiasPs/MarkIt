using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Repositories.Base;
using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.DapperConfig
{
    public class DbContext<TEntity> : IDbContext<TEntity> where TEntity : class
    {
        private IUnitOfWorkFactory UnitOfWorkFactory;
        
        public DbContext(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.UnitOfWorkFactory = unitOfWorkFactory;
        }               

        private UnitOfWork unitOfWork;
        public UnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = UnitOfWorkFactory.Create());

        public IRepositoryBase<TEntity> Repository { get { return new RepositoryBase<TEntity>(this); } }

        public void Commit()
        {
            try
            {
                UnitOfWork.Commit();
            }
            finally
            {
                Reset();
            }
        }
        public void Rollback()
        {
            try
            {
                UnitOfWork.Rollback();
            }
            finally
            {
                Reset();
            }
        }
        private void Reset()
        {
            unitOfWork = null;
        }            
    }
}
