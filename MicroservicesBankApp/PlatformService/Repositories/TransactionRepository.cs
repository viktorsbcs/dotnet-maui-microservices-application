using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task ExecuteTransaction(Account fromAccount, Account toAccount)
        {
            throw new NotImplementedException();
        }
    }
}
