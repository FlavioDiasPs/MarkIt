using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace MarkIt.Core.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetByBarcode(string name);
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetRelevantProducts();        
    }    
}
