using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class MediaRepository : IMediaRepository
{
    private readonly SteamDbContext _context;

    public MediaRepository(SteamDbContext context) => _context = context;

    public async Task<int?> AddAsync(Media media, CancellationToken ct)
    {
        await _context.Medias.AddAsync(media, ct);
        await _context.SaveChangesAsync(ct);
        return media.Id;
    }

    public async Task<IEnumerable<Media>> GetByGameIdAsync(int gameId, CancellationToken ct)
    {
        return await _context.Medias.AsNoTracking().Where(m => m.GameId == gameId).ToListAsync(ct);
    }

    public async Task<Media?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Medias.FirstOrDefaultAsync(m => m.Id == id, ct);
    }
}