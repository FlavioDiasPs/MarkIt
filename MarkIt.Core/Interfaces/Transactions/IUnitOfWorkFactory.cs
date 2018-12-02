
namespace MarkIt.Core.Interfaces.Transactions
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
