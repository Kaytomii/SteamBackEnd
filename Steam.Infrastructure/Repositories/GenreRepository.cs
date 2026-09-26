using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Steam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly SteamDbContext _context;

    public GenreRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Genres.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Genre?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id, ct);
    }
}