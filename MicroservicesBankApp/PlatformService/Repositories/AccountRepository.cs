using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public Task AddToAccountBalance(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task CreateAccount(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccount(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawFromAccountBalance(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
