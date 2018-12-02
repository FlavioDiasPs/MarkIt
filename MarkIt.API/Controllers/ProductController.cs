using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Services;
using MarkIt.Core.Interfaces.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MarkIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Base.ControllerBase
    {
        private readonly IMarketService _marketService;
        private readonly IProductService _productService;
        private readonly IPriceService _priceService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;                  

        public ProductController(IUnitOfWorkFactory unitOfWorkFactory, IMarketService marketService, IProductService productService, IPriceService priceService) : base(unitOfWorkFactory)
        {
            _marketService = marketService;
            _productService = productService;
            _priceService = priceService;
            _unitOfWorkFactory = unitOfWorkFactory;                        
        }

        [HttpGet("{productBarCode}")]
        public IActionResult GetPriceByProductBarCode(string productBarCode)
        {
            var result = _priceService.GetPricesByProductBarCode(productBarCode);

            if (result is null) return NotFound(productBarCode);

            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var result = _productService.GetByName(name);

            if (result is null) return NotFound(name);

            return Ok(result);
        }

        [HttpPost()]
        public int AddRandomProduct()
        {
            Price price = new Price();
            //price.Valor = Convert.ToDecimal(new Random(12332).NextDouble());

            Product product = new Product(){
                Name = new Random(12332).NextDouble().ToString()
            };

            _productService.Add(product);

            return StatusCodes.Status200OK;
        }

        [HttpDelete]
        public int DeleteProductById([FromBody] Product product)
        {
            _productService.Remove(product);            

            return StatusCodes.Status200OK;
        }

        //[HttpGet("{id}")]
        //public IActionResult GetLastProduct( int id)
        //{
        //    var result = _productService.GetById(id);

        //    if (result is null) return NotFound(id);
            
        //    return Ok(result);                                
        //}
    }
}
