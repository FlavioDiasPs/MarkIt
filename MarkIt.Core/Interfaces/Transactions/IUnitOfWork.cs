using System.Data;

namespace MarkIt.Core.Interfaces.Transactions
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; set; }

        void Commit();
        void Rollback();
    }
}
