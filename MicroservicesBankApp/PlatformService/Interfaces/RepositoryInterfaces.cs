using PlatformService.Models;

namespace PlatformService.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(string firstName, string secondName);
        public Task<User> GetUserAsync(string userId);
        public Task<List<Account>> GetAccountsBelongingToUserAsync(User user);
    }

    public interface IAccountRepository
    {
        public Task CreateAccountAsync(User user);
        public Task<Account> GetAccountAsync(string accountId);
        public Task AddToAccountBalanceAsync(decimal amount);
        public Task WithdrawFromAccountBalanceAsync(decimal amount);
    }

    public interface ITransactionRepository
    {
        public Task ExecuteTransactionAsync(Account fromAccount, Account toAccount);
    }
}
