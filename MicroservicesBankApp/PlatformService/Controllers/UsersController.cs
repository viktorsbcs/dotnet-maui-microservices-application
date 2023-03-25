using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository userRepo, ILogger<UsersController> logger) {
            this._userRepo = userRepo;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            _logger.LogInformation($"{nameof(UsersController)} - GetUser(id={id})");

            return Ok(user);
        }
    }
}
