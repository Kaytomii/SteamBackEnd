using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Steam.Infrastructure.Data;

namespace Steam.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseCors("AllowAll");

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SteamDbContext>();

                DbInitializer.InitializeAsync(db).GetAwaiter().GetResult();
            }
        }
    }
}
