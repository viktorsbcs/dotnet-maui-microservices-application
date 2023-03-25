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

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepo.GetUserAsync(id);

            return Ok(user);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> CreateUser([FromBody] User userData)
        {
            return Ok(userData);
        }

        
    }
}
