using PlatformService.Data;
using PlatformService.Models;
using PlatformService.Utilities;


namespace PlatformService.Repositories
{
    public class UsersRepository : IUserReporsitory
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            this._context = context;
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

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public List<Account> GetAccountsBelongingToUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userId)
        {
            throw new NotImplementedException();
        }



    }


}
