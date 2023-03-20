using PlatformService.Models;

namespace PlatformService.Repositories
{
    public interface IUserReporsitory
    {
        public Task CreateUser(string firstName, string secondName);
        public Task<User> GetUser(string userId);
        public Task<List<Account>> GetAccountsBelongingToUser(User user);
    }

    public interface IAccountReporsitory
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
