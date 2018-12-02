
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories;

namespace MarkIt.Infra.Data.Transactions
{
    public interface IDbContext
    {
        UnitOfWork UnitOfWork { get; }
        ProductRepository Product { get;  }
        MarketRepository Market { get;  }

        void Commit();
        void Rollback();
    }
}
