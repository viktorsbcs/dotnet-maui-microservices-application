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

        public Task AddToAccountBalanceAsync(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task CreateAccountAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<List<Account>> IAccountRepository.GetAccountsBelongingToUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountAsync(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawFromAccountBalanceAsync(decimal amount)
        {
            throw new NotImplementedException();
        }


    }
}
