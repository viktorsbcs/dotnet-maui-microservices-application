using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Repositories;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
            });

            builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
            builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();

            var app = builder.Build();

            PrepareDb.PreparePopulation(app);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}



