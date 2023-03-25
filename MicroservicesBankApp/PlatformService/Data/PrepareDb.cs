using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using PlatformService.Utilities;

namespace PlatformService.Data
{
    public static class PrepareDb
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<AppDbContext>();
                SeedData(service);
            }
        }

        public static void SeedData(AppDbContext dbContext)
        {
            Console.WriteLine("---> Seeding data start");
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
                UserId = "1000",
                FirstName = "Jack",
                SecondName = "Stevensen",
                BirthDate = new DateTime(1984,3,12),
                Email = "jstevensen@emailserver.com",
                Accounts = new List<Account>()
            };

            var user2 = new User
            {
                UserId = "1001",
                FirstName = "Marta",
                SecondName = "Kelvin",
                BirthDate = new DateTime(2003, 10, 29),
                Email = "marta@amail.jp",
                Accounts = new List<Account>()
            };

            var user3 = new User
            {
                UserId = "1002",
                FirstName = "Sam",
                SecondName = "Adams",
                BirthDate = new DateTime(1991, 8, 2),
                Email = "adamssam@bambomail.com",
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


            dbContext.Accounts.AddRange(account1, account2, account3, account4);
            dbContext.Users.AddRange(user1,user2, user3);   
            dbContext.Transactions.AddRange(transaction1);

            dbContext.SaveChanges();

            Console.WriteLine("---> Seeding data finish");



        }
    }
}
