using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steam.Infrastructure.Data;

namespace Steam.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SteamDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
            });

            var app = builder.Build();
            app.UseCors("AllowAll");

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SteamDbContext>();

                await db.Database.MigrateAsync();
                await DbInitializer.InitializeAsync(db);
            }

            await app.RunAsync();
        }
    }
}