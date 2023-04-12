using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;
using PlatformService.Utilities;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> CreateUserAsync(string firstName, string secondName, string email, DateTime birthDate)
        {
            var newUser = new User()
            {
                UserId = Helpers.GeneretaRandomId(),
                FirstName = firstName,
                SecondName = secondName,
                BirthDate = birthDate,
                Email = email,
                Accounts = new List<Account>()
            };

            //Find if existing user with such if exist
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
