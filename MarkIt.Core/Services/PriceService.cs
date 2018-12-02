using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MarkIt.Core.Services
{
    public class PriceService : IPriceService
    {
        private readonly IDbContext _context;

        public PriceService(IDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Price> GetAll()
        {
            var result = _context.Price.GetAll();
            _context.Commit();

            return result;
        }
        public Price GetById(int id)
        {            
            var result = _context.Price.GetById(id);
            _context.Commit();

            return result;
        }        

        public long Add(Price price)
        {
            var result = _context.Price.Add(price);
            _context.Commit();

            return result;
        }
        public bool Remove(Price price)
        {
            var result = _context.Price.Remove(price);
            _context.Commit();

            return result;
        }
        public bool Update(Price price)
        {
            var result = _context.Price.Update(price);
            _context.Commit();

            return result;
        }


        public IEnumerable<Price> GetPricesByProductId(int productId)
        {
            return _context.Price.GetPricesByProductId(productId);
        }
    }
}
