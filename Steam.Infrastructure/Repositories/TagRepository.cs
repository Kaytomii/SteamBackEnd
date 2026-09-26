using Steam.Application.Interfaces.Repository;
using Steam.Domain.Model;
using Steam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly SteamDbContext _context;

    public TagRepository(SteamDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Tags.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Tag?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Tags.FirstOrDefaultAsync(t => t.Id == id, ct);
    }
}