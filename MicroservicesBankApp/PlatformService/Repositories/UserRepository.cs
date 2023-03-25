using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;
using PlatformService.Utilities;


namespace PlatformService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateUser(string firstName, string secondName)
        {
            var newUser = new User()
            {
                UserId = Helpers.GeneretaRandomUserId(),
                FirstName = firstName,
                SecondName = secondName,
                Accounts = new List<Account>()
            };

            //Find if existing user with such if exist
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Account>> GetAccountsBelongingToUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            return user;
        }
    }
}
