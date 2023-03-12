using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BankOperationsDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.Users.Any() || this.Accounts.Any() || this.Transactions.Any()) return;
            modelBuilder.Seed();
        }



    }

}
