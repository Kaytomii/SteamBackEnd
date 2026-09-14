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
                Email = "admin@example.com",
                Role = UserRole.Admin
            };

            db.Users.Add(admin);
            await db.SaveChangesAsync();
        }
    }
}
