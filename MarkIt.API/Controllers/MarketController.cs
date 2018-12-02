using MarkIt.Core.Interfaces.Services;
using MarkIt.Core.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarkIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : Base.ControllerBase
    {
        private readonly IMarketService _marketService;        
        private readonly IProductService _productService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        //private readonly IMapper _mapper;        

        public MarketController(IUnitOfWorkFactory unitOfWorkFactory, IMarketService marketService, IProductService productService) : base(unitOfWorkFactory)
        {
            _marketService = marketService;
            _productService = productService;
            _unitOfWorkFactory = unitOfWorkFactory;
            
            //_mapper = mapper;            
        }
        

        [HttpGet]
        public IEnumerable<Core.Entities.Market> AllMarkets()
        {
            return _marketService.GetAll();            
        }      
    }
}
