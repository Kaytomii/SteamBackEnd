using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class AchievementRepository : IAchievementRepository
{
    private readonly SteamDbContext _context;

    public AchievementRepository(SteamDbContext context) => _context = context;

    public async Task<int?> AddAsync(Achievement achievement, CancellationToken ct)
    {
        await _context.Achievements.AddAsync(achievement, ct);
        await _context.SaveChangesAsync(ct);
        return achievement.Id;
    }

    public async Task<IEnumerable<Achievement>> GetByGameIdAsync(int gameId, CancellationToken ct)
    {
        return await _context.Achievements.AsNoTracking().Where(a => a.GameId == gameId).ToListAsync(ct);
    }

    public async Task<Achievement?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Achievements.FirstOrDefaultAsync(a => a.Id == id, ct);
    }
}