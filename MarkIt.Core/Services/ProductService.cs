using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MarkIt.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbContext _context;

        public ProductService(IDbContext context)
        {
            _context = context;
        }
            
        public IEnumerable<Product> GetAll()
        {            
            var result = _context.Product.GetAll();
            _context.Commit();

            return result;
        }
        public Product GetById(int id)
        {            
            var result = _context.Product.GetById(id);
            _context.Commit();

            return result;
        }
        public IEnumerable<Product> GetByName(string name)
        {
            var result = _context.Product.GetByName(name);
            _context.Commit();

            return result;
        }

        public long Add(Product obj)
        {
            var result = _context.Product.Add(obj);
            _context.Commit();

            return result;
        }
        public bool Remove(Product obj)
        {
            var result = _context.Product.Remove(obj);
            _context.Commit();

            return result;
        }
        public bool Update(Product obj)
        {
            var result = _context.Product.Update(obj);
            _context.Commit();

            return result;
        }
    }          
}
