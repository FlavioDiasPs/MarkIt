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


        public void Add(Product obj)
        {
            _context.Product.Add(obj);
            _context.Commit();
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

        public void Remove(Product obj)
        {
            _context.Product.Remove(obj);
            _context.Commit();
        }

        public void Update(Product obj)
        {
            _context.Product.Update(obj);
            _context.Commit();
        }
    }
}
