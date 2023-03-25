using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Interfaces;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository accountRepo) {
            this._accountRepo = accountRepo;
        }
    }
}
