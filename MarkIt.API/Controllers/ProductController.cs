
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Services;
using MarkIt.Infra.Data.Transactions;
using MarkIt.Infra.Data.Transactions.Interfaces;
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
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDbContext _dbContext;
        //private readonly IMapper _mapper;        

        public ProductController(IDbContext dbContext, IUnitOfWorkFactory unitOfWorkFactory, IMarketService marketService, IProductService productService) : base(unitOfWorkFactory)
        {
            _marketService = marketService;
            _productService = productService;
            _unitOfWorkFactory = unitOfWorkFactory;
            _dbContext = dbContext;
            //_mapper = mapper;            
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> AllProducts()
        {
            return _dbContext.Product.GetAll();
        }

        [HttpPost]
        public int AddRandomProduct()
        {
            _dbContext.Product.AddProduct(
                    new Product() {
                        Name = new Random(12332).NextDouble().ToString()
                    });
            _dbContext.Commit();
            return StatusCodes.Status200OK;
        }
    }
}
