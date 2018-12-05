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
        private readonly IProductService _productService;
        private readonly IPriceService _priceService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;                  

        public ProductController(IUnitOfWorkFactory unitOfWorkFactory, IProductService productService, IPriceService priceService) : base(unitOfWorkFactory)
        {            
            _productService = productService;
            _priceService = priceService;
            _unitOfWorkFactory = unitOfWorkFactory;                        
        }

        [HttpGet("BarCode/{barcode}")]
        public IActionResult GetPriceByProductBarCode(string barcode)
        {
            var result = _productService.GetByBarcode(barcode);

            if (result is null) return NotFound(barcode);

            return Ok(result);
        }

        [HttpGet("Name/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var result = _productService.GetByName(name);

            if (result is null) return NotFound(name);

            return Ok(result);
        }        

        [HttpGet]
        public IActionResult GetRelevantProducts()
        {
            var result = _productService.GetRelevantProducts();

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}
