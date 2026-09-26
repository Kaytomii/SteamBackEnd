using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Steam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly SteamDbContext _context;

    public GameRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task<int?> AddAsync(Game game, CancellationToken ct)
    {
        await _context.Games.AddAsync(game, ct);
        await _context.SaveChangesAsync(ct);
        return game.Id;
    }

    public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Games.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Game?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Games
            .Include(g => g.GameGenres)
            .Include(g => g.GameTags)
            .Include(g => g.Media)
            .FirstOrDefaultAsync(g => g.Id == id, ct);
    }
}