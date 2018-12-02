using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MarkIt.Core.Services
{
    public class MarketService : IMarketService
    {
        private readonly IDbContext _context;

        public MarketService(IDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Market> GetAll()
        {
            var result = _context.Market.GetAll();
            _context.Commit();

            return result;
        }
        public Market GetById(int id)
        {
            var result = _context.Market.GetById(id);
            _context.Commit();

            return result;
        }

        public long Add(Market obj)
        {
            var result = _context.Market.Add(obj);
            _context.Commit();

            return result;
        }
        public bool Remove(Market obj)
        {
            var result = _context.Market.Remove(obj);
            _context.Commit();

            return result;
        }
        public bool Update(Market obj)
        {
            var result = _context.Market.Update(obj);
            _context.Commit();

            return result;
        }
    }
}
