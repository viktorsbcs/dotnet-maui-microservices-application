using PlatformService.Models;

namespace PlatformService.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(string firstName, string secondName);
        public Task<User> GetUser(string userId);
        public Task<List<Account>> GetAccountsBelongingToUser(User user);
    }

    public interface IAccountRepository
    {
        public Task CreateAccount(User user);
        public Task<Account> GetAccount(string accountId);
        public Task AddToAccountBalance(decimal amount);
        public Task WithdrawFromAccountBalance(decimal amount);
    }

    public interface ITransactionRepository
    {
        public Task ExecuteTransaction(Account fromAccount, Account toAccount);
    }
}
