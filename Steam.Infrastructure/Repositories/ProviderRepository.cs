using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class ProviderRepository : IProviderRepository
{
    private readonly SteamDbContext _context;

    public ProviderRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Provider>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Providers.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Provider?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Providers.FirstOrDefaultAsync(p => p.Id == id, ct);
    }
}