using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class AccountRepository : IAccountReporsitory
    {
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
