using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Services.Base;
using System.Collections.Generic;

namespace MarkIt.Core.Interfaces.Services
{
    public interface IPriceService : IServiceBase<Price>
    {
        IEnumerable<Price> GetPricesByProductBarCode(string productBarCode);
        IEnumerable<Price> GetPricesByProductId(int id);
    }
}
