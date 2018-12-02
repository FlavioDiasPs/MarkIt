using MarkIt.Infra.Data.Repositories;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;


namespace MarkIt.Infra.Data.DapperConfig
{
    public class DbContext : IDbContext
    {
        private IUnitOfWorkFactory UnitOfWorkFactory;
        
        public DbContext(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }               

        private UnitOfWork unitOfWork;
        public UnitOfWork UnitOfWork => unitOfWork ?? (unitOfWork = UnitOfWorkFactory.Create());
        
        private ProductRepository product;
        public ProductRepository Product => product ?? (product = new ProductRepository(this));

        private MarketRepository market;
        public MarketRepository Market => market ?? (market = new MarketRepository(this));

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
