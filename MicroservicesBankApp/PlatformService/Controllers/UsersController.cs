using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
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

        [HttpGet("api/[controller]/get/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            _logger.LogInformation($"{nameof(GetUserById)} - triggered");

            return Ok(user);
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        public async Task<IActionResult> CreateUser([FromBody] User userData)
        {
            return Ok(userData);
        }

        
    }
}
