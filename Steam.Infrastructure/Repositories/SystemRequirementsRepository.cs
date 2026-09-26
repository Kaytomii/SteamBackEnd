using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class SystemRequirementsRepository : ISystemRequirementsRepository
{
    private readonly SteamDbContext _context;

    public SystemRequirementsRepository(SteamDbContext context) => _context = context;

    public async Task<int?> AddAsync(SystemRequirements req, CancellationToken ct)
    {
        await _context.SystemRequirements.AddAsync(req, ct);
        await _context.SaveChangesAsync(ct);
        return req.Id;
    }

    public async Task<SystemRequirements?> GetByGameIdAsync(int gameId, CancellationToken ct)
    {
        return await _context.SystemRequirements.FirstOrDefaultAsync(r => r.GameId == gameId, ct);
    }
}