using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using PlatformService.DataTransferObjects;
using PlatformService.Interfaces;
using PlatformService.Models;
using PlatformService.Utilities;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, ILogger<UsersController> logger, IMapper mapper) {
            this._userRepo = userRepo;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepo.GetUserAsync(id);

            var userDto = _mapper.Map<UserReadDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var newUser = _mapper.Map<User>(userCreateDto);

            newUser.UserId = Helpers.GeneretaRandomUserId();

            return Ok(newUser);
        }

        
    }
}
