using System;
using System.Collections.Generic;
using System.Text;

namespace MarkIt.Infra.Data.Transactions.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork Create();
    }
}
