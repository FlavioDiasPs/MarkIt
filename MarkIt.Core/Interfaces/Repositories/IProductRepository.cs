using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace MarkIt.Core.Interfaces.Repositories
{
    public interface IPriceRepository : IRepositoryBase<Price>
    {
        IEnumerable<Price> GetPricesByProductBarCode(string productBarCode);
    }    
}
