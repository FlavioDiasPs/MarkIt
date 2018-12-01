
using MarkIt.Core.Interfaces.Services;
using MarkIt.Infra.Data.Transactions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarkIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Base.ControllerBase
    {
        private readonly IMarketService _marketService;        
        private readonly IProductService _productService;        
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        //private readonly IMapper _mapper;        

        public ProductController(IUnitOfWorkFactory unitOfWorkFactory, IMarketService marketService, IProductService productService) : base(unitOfWorkFactory)
        {
            _marketService = marketService;
            _productService = productService;
            _unitOfWorkFactory = unitOfWorkFactory;
            
            //_mapper = mapper;            
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Core.Entities.Product> AllProducts()
        {
            return _productService.GetAll();            
        }      
    }
}
