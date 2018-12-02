using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Services;
using MarkIt.Core.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace MarkIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : Base.ControllerBase
    {
        private readonly IMarketService _marketService;
        private readonly IProductService _productService;
        private readonly IPriceService _priceService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;                     

        public PriceController(IUnitOfWorkFactory unitOfWorkFactory, IPriceService priceService, IMarketService marketService, IProductService productService) : base(unitOfWorkFactory)
        {
            _marketService = marketService;
            _productService = productService;
            _priceService = priceService;
            _unitOfWorkFactory = unitOfWorkFactory;                           
        }
       
        //[HttpGet("id")]
        //public IActionResult GetPriceByProductId(int productId)
        //{
        //    var result = _priceService.GetPricesByProductId(productId);

        //    if (result is null) return NotFound(productId);

        //    return Ok(result);            
        //}

        //[HttpGet("id")]
        //public IActionResult GetLastProduct(int id, date)
        //{
        //    var result = _productService.GetById(id);

        //    if (result is null) return NotFound(id);

        //    return Ok(result);
        //}

        [HttpPost("")]
        public IActionResult PostNewProduct([FromBody] Price price)
        {
            if (!ModelState.IsValid) return BadRequest(price);

            var result = _priceService.Add(price);

            return Ok(result);
        }

        
    }
}
