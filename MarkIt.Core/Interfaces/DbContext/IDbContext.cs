using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Transactions;

namespace MarkIt.Core.Interfaces.DbContext
{
    public interface IDbContext
    {
        IUnitOfWork UnitOfWork { get; }
        IProductRepository Product { get; }
        IMarketRepository Market { get; }
        IPriceRepository Price { get; }

        void Commit();
        void Rollback();
    }
}
