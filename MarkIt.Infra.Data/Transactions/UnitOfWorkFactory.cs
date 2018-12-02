using MarkIt.Core.Interfaces.Transactions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MarkIt.Infra.Data.Transactions
{
    public class UnitOfWorkFactory<TConnection> : IUnitOfWorkFactory where TConnection : IDbConnection, new()
    {
        private readonly IConfiguration _configuration;
        public UnitOfWorkFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        TConnection _connection;
        public IDbConnection Connection
        {
            get
            {
                if (string.IsNullOrEmpty(_connection?.ConnectionString))
                    _connection = new TConnection()
                    {
                        ConnectionString = _configuration.GetConnectionString("MyConnectionString")
                    };

                return _connection;
            }
        }
        private IDbConnection CreateOpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An error occured while connecting to the database. See innerException for details.", exception);
            }

            return Connection;
        }
        public IUnitOfWork Create()
        {
            return new UnitOfWork(CreateOpenConnection());
        }
    }
}
