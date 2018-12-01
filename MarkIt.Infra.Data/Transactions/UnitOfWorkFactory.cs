using MarkIt.Infra.Data.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MarkIt.Infra.Data.Transactions
{
    public class UnitOfWorkFactory<TConnection> : IUnitOfWorkFactory where TConnection : IDbConnection, new()
    {
        private readonly string connectionString;

        public UnitOfWorkFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("connectionString cannot be null");
            }

            this.connectionString = connectionString;
        }

        public UnitOfWork Create()
        {
            return new UnitOfWork(CreateOpenConnection());
        }

        private IDbConnection CreateOpenConnection()
        {
            var conn = new TConnection();
            conn.ConnectionString = connectionString;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An error occured while connecting to the database. See innerException for details.", exception);
            }

            return conn;
        }
    }
}
