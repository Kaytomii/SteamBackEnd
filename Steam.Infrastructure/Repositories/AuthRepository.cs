using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Steam.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly SteamDbContext _context;

    public AuthRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
    }

    public async Task AddUserAsync(User user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task SaveRefreshTokenAsync(RefreshToken token, CancellationToken ct)
    {
        await _context.RefreshTokens.AddAsync(token, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(string token, CancellationToken ct)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token, ct);
    }

    public async Task RemoveRefreshTokenAsync(int id, CancellationToken ct)
    {
        var entity = await _context.RefreshTokens.FindAsync(new object[] { id }, ct);
        if (entity != null)
        {
            _context.RefreshTokens.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}