using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Transactions;
using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Transactions;


namespace MarkIt.Infra.Data.DapperConfig
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
        
        private IProductRepository product;
        public IProductRepository Product => product ?? (product = new ProductRepository(this));

        private IMarketRepository market;
        public IMarketRepository Market => market ?? (market = new MarketRepository(this));        

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
