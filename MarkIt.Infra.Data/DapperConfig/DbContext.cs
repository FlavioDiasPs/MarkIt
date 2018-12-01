using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.DapperConfig
{
    public class DbContext : IDbContext
    {
        private IUnitOfWorkFactory unitOfWorkFactory;
        
        public DbContext(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        private IProductRepository product;
        public IProductRepository Product => product ?? (product = new ProductRepository(UnitOfWork));

        private IMarketRepository market;
        public IMarketRepository Market => market ?? (market = new MarketRepository(UnitOfWork));

        private UnitOfWork unitOfWork;
        protected UnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = unitOfWorkFactory.Create());        

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
            product = null;
        }
    }
}
