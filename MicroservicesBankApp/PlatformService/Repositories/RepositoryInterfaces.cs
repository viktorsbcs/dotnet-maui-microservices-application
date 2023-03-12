using PlatformService.Models;

namespace PlatformService.Repositories
{
    public interface IUserReporsitory
    {
        public void CreateUser(string firstName, string secondName);
        public User GetUser(string userId);
        public List<Account> GetAccountsBelongingToUser(User user);
    }

    public interface IAccountReporsitory
    {
        public void CreateAccount(User user);
        public Account GetAccount(string accountId);
        public void AddToAccountBalance(decimal amount);
        public void WithdrawFromAccountBalance(decimal amount);
    }

    public interface ITransactionRepository
    {
        public void ExecuteTransaction(Account fromAccount, Account toAccount);
    }
}
