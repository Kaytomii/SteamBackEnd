using Steam.Application.Interfaces.Repository;
using Steam.Infrastructure.Data;
using Steam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly SteamDbContext _context;

    public RefreshTokenRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(RefreshToken token, CancellationToken ct)
    {
        await _context.RefreshTokens.AddAsync(token, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token, ct);
    }

    public async Task RemoveAsync(int id, CancellationToken ct)
    {
        var entity = await _context.RefreshTokens.FindAsync(new object[] { id }, ct);
        if (entity != null)
        {
            _context.RefreshTokens.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}