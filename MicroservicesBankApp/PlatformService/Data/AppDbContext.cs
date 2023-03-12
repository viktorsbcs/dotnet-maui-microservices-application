using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BankOperationsDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Jack",
                SecondName = "Stevensen",
                Accounts = new List<Account>()
            };

            var user2 = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Marta",
                SecondName = "Kelvin",
                Accounts = new List<Account>()
            };

            var user3 = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Sam",
                SecondName = "Adams",
                Accounts = new List<Account>()
            };

            var account1 = new Account { AccountId = Guid.NewGuid(), User = user1, Balance = 3000 };
            var account2 = new Account { AccountId = Guid.NewGuid(), User = user2, Balance = 1000 };
            var account3 = new Account { AccountId = Guid.NewGuid(), User = user3, Balance = 500 };
            var account4 = new Account { AccountId = Guid.NewGuid(), User = user2, Balance = 50 };

            user1.Accounts.Add(account1);
            user2.Accounts.Add(account2);
            user2.Accounts.Add(account4);
            user3.Accounts.Add(account3);

            var transaction1 = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                FromAccount = account1,
                ToAccount = account3,
                Amount = 300
            };

            modelBuilder.Entity<Account>().HasData(account1, account2, account3, account4);
            modelBuilder.Entity<User>().HasData(user1, user2, user3);
            modelBuilder.Entity<Transaction>().HasData(transaction1);   

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }

}
