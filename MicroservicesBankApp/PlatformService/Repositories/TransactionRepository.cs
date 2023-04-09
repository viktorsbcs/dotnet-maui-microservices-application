using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepo;

        public TransactionRepository(AppDbContext dbContext, IAccountRepository accountRepo)
        {
            _dbContext = dbContext;
            _accountRepo = accountRepo;
        }
        public async Task ExecuteTransactionAsync(string fromAccountId, string toAccountId, decimal amount)
        {
            await _accountRepo.WithdrawFromAccountBalanceAsync(fromAccountId, amount);
            await _accountRepo.AddToAccountBalanceAsync(toAccountId, amount); 

        }
    }
}
