using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using PlatformService.Utilities;

namespace PlatformService.Data
{
    public static class AppDbContextSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<string> randomUserIdList = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    var randomUserId = Helpers.GeneretaRandomUserId();

                    if (randomUserIdList.Exists(x => x.Equals(randomUserId)))
                    {
                        continue;
                    }

                    randomUserIdList.Add(randomUserId);
                    break;
                }
            }

            var user1 = new User
            {
                UserId = randomUserIdList[0],
                FirstName = "Jack",
                SecondName = "Stevensen",
                Accounts = new List<Account>()
            };

            var user2 = new User
            {
                UserId = randomUserIdList[1],
                FirstName = "Marta",
                SecondName = "Kelvin",
                Accounts = new List<Account>()
            };

            var user3 = new User
            {
                UserId = randomUserIdList[2],
                FirstName = "Sam",
                SecondName = "Adams",
                Accounts = new List<Account>()
            };

            var account1 = new Account { AccountId = Guid.NewGuid().ToString(), User = user1, Balance = 3000 };
            var account2 = new Account { AccountId = Guid.NewGuid().ToString(), User = user2, Balance = 1000 };
            var account3 = new Account { AccountId = Guid.NewGuid().ToString(), User = user3, Balance = 500 };
            var account4 = new Account { AccountId = Guid.NewGuid().ToString(), User = user2, Balance = 50 };

            user1.Accounts.Add(account1);
            user2.Accounts.Add(account2);
            user2.Accounts.Add(account4);
            user3.Accounts.Add(account3);

            var transaction1 = new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                FromAccount = account1,
                ToAccount = account3,
                Amount = 300
            };

            modelBuilder.Entity<Account>().HasData(account1, account2, account3, account4);
            modelBuilder.Entity<User>().HasData(user1, user2, user3);
            modelBuilder.Entity<Transaction>().HasData(transaction1);
        }
    }
}
