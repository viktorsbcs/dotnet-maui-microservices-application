﻿using PlatformService.Models;

namespace PlatformService.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(string firstName, string secondName, string email, DateTime birthDate);
        public Task<User> GetUserAsync(string userId);
        public Task<List<User>> GetAllUsersAsync();
    }

    public interface IAccountRepository
    {
        public Task CreateAccountAsync(string userId);
        public Task<Account> GetAccountAsync(string accountId);
        public Task<List<Account>> GetAccountsBelongingToUserAsync(string userId);
        public Task AddToAccountBalanceAsync(string accountId, decimal amount);
        public Task WithdrawFromAccountBalanceAsync(string accountId, decimal amount);
    }

    public interface ITransactionRepository
    {
        public Task ExecuteTransactionAsync(string fromAccountId, string toAccountId, decimal amount);
    }
}
