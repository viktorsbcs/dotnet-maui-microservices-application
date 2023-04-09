using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;
using PlatformService.Utilities;
using System.ComponentModel;
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

        public async Task CreateAccountAsync(string userId)
        {
            var newAccountId = string.Empty;

            while (true)
            {
                newAccountId = Helpers.GeneretaRandomId();

                if (await _dbContext.Accounts.AnyAsync(x => x.AccountId.Equals(newAccountId)))
                {
                    continue;
                }
                break;
            }

            var user = await _dbContext.Users.Where(x => x.UserId.Equals(userId)).FirstAsync();

            var account = new Account()
            {
                AccountId = newAccountId,
                Balance = 0,
                User = user
            };

            user.Accounts.Add(account);

            await _dbContext.Accounts.AddAsync(account);
            _dbContext.Users.Update(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAccountsBelongingToUserAsync(string userId)
        {
            var user = await _dbContext.Users.Where(x => x.UserId.Equals(userId)).FirstAsync();

            return user.Accounts;
        }

        public async Task<Account> GetAccountAsync(string accountId)
        {
            return await _dbContext.Accounts.FirstAsync(x => x.AccountId.Equals(accountId));
        }

        public async Task AddToAccountBalanceAsync(string accountId, decimal amount)
        {
            var account = await _dbContext.Accounts.Where(x => x.AccountId.Equals(accountId)).FirstAsync();

            account.Balance += amount;

            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task WithdrawFromAccountBalanceAsync(string accountId, decimal amount)
        {
            var account = await _dbContext.Accounts.Where(x => x.AccountId.Equals(accountId)).FirstAsync();

            if ((account.Balance - amount) < 0)
            {
                throw new Exception("Not enough funds");
            }
            else
            {
                account.Balance -= amount;
            }

            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();
        }


    }
}
