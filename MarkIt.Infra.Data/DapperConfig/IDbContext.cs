using MarkIt.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.Transactions
{
    public interface IDbContext
    {
        IProductRepository Product { get; }
        IMarketRepository Market { get; }

        void Commit();
        void Rollback();
    }
}
