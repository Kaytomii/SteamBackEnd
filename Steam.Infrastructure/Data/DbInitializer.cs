using Steam.Domain.Enum;
using Steam.Domain.Enum;
using Steam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(SteamDbContext db)
    {
        var adminExists = await db.Users
            .AnyAsync(u => u.Role == UserRole.Admin);

        if (!adminExists)
        {
            var admin = new User
            {
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "CHANGE_ME",
                Description = "System administrator",
                Role = UserRole.Admin
            };

            db.Users.Add(admin);
            await db.SaveChangesAsync();
        }
    }
}
