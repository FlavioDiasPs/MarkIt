using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MarkIt.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public void Add(Product obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Product> GetAll()
        {            
            return _repository.GetAll();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Product obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Product obj)
        {
            _repository.Update(obj);
        }
    }
}
