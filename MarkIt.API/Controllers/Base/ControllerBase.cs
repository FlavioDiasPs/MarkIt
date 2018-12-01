using MarkIt.Infra.Data.Transactions.Interfaces;

namespace MarkIt.Api.Controllers.Base
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ControllerBase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
