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
            _userRepo = userRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("find/{id}", Name = nameof(GetUserById))]
        [ProducesResponseType(typeof(UserReadDto), 200)]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            
            if(user is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpGet("all", Name =nameof(GetAllUsers))]
        [ProducesResponseType(typeof(List<UserReadDto>), 200)]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _userRepo.GetAllUsersAsync();
            var userReadDtoList = new List<UserReadDto>();

            foreach (var user in userList)
            {
                var userReadDto = _mapper.Map<UserReadDto>(user);
                userReadDtoList.Add(userReadDto);
            }

            return Ok(userReadDtoList);
        }

        [HttpPost]
        [Route("create", Name = nameof(CreateUser))]
        [ProducesResponseType(typeof(UserReadDto), 200)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var newUser = _mapper.Map<User>(userCreateDto);

            var createdUser = await _userRepo.CreateUserAsync(newUser.FirstName, newUser.SecondName, newUser.Email, newUser.BirthDate);
            var userReadDto = _mapper.Map<UserReadDto>(createdUser);

            return CreatedAtRoute(nameof(CreateUser), new { userId = userReadDto.UserId, userReadDto } );
        }

        
    }
}
