using System.Data;
using MarkIt.Core.Interfaces.Transactions;

namespace MarkIt.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDbConnection connection)
        {
            Transaction = connection.BeginTransaction();
        }
        public IDbTransaction Transaction { get; set; }
        public void Commit()
        {
            try
            {
                Transaction.Commit();
                Transaction.Connection?.Close();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction?.Dispose();
                Transaction.Connection?.Dispose();
                Transaction = null;
            }
        }
        public void Rollback()
        {
            try
            {
                Transaction.Rollback();
                Transaction.Connection?.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                Transaction?.Dispose();
                Transaction.Connection?.Dispose();
                Transaction = null;
            }
        }
    }
}
