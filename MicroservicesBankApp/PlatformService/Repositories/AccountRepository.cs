using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;
using System.Reflection.Metadata.Ecma335;

namespace PlatformService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddToAccountBalance(decimal amount)
        {

            return new Task<decimal>(() => amount);
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
