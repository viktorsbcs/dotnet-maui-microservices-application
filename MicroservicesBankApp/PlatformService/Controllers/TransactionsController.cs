using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Interfaces;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepo;

        public TransactionsController(ITransactionRepository transactionRepo) {
            this._transactionRepo = transactionRepo;
        }
    }
}
