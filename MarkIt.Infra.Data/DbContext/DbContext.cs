﻿using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Transactions;
using MarkIt.Infra.Data.Repositories;


namespace MarkIt.Infra.Data.DbContext
{
    public class DbContext : IDbContext
    {
        private IUnitOfWorkFactory UnitOfWorkFactory;
        
        public DbContext(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }               

        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = UnitOfWorkFactory.Create());

        #region ############ Repositories ############

        private IProductRepository product;
        public IProductRepository Product => product ?? (product = new ProductRepository(this));

        private IMarketRepository market;
        public IMarketRepository Market => market ?? (market = new MarketRepository(this));

        private IPriceRepository price;
        public IPriceRepository Price => price ?? (price = new PriceRepository(this));

        #endregion repositories

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
