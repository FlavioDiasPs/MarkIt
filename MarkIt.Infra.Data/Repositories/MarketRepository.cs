using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace MarkIt.Infra.Data.Repositories
{
    public class MarketRepository : IMarketRepository
    {
        protected readonly IDbConnection connection;
        protected readonly IDbTransaction transaction;

        public MarketRepository(UnitOfWork unitOfWork)
        {
            connection = unitOfWork.Transaction.Connection;
            transaction = unitOfWork.Transaction;
        }

        public void Add(Market obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Market> FromSql(object obj, string sql, SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Market> GetAll()
        {
            return connection.QuerySingleOrDefault<IEnumerable<Market>>("select * from dbo.Market", transaction: transaction);
        }

        public Market GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Market> GetClosestMarkets(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Market> Queryable()
        {
            throw new NotImplementedException();
        }

        public void Remove(Market obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Market obj)
        {
            throw new NotImplementedException();
        }
    }
}
