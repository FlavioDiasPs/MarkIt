using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MarkIt.Infra.Data.Transactions.Interfaces
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; set; }

        void Commit();
        void Rollback();
    }
}
