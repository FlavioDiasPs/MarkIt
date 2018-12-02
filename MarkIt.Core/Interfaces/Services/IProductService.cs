using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Services.Base;
using System.Collections.Generic;

namespace MarkIt.Core.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> GetByName(string name);
    }    
}
