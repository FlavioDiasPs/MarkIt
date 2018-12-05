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
        private readonly IPriceService _priceService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public PriceController(IUnitOfWorkFactory unitOfWorkFactory, IPriceService priceService) : base(unitOfWorkFactory)
        {
            _priceService = priceService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpGet("productid/{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _priceService.GetPricesByProductId(id);

            if (result is null) return NotFound(id);

            return Ok(result);
        }
    }
}
