using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Steam.Application.Interfaces.Repository;
using Steam.Infrastructure.Data;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Infrastructure.Repositories;

public class WishlistRepository : IWishlistRepository
{
    private readonly SteamDbContext _context;

    public WishlistRepository(SteamDbContext context)
    {
        _context = context;
    }
    public async Task<List<UserWishlist>> GetByUserIdAsync(Guid userId)
    {
        return await _context.UserWishlists
            .Where(w => w.UserId == userId)
            .Include(w => w.Game)
            .ToListAsync();
    }
    public async Task<UserWishlist?> GetAsync(Guid userId, int gameId)
    {
        return await _context.UserWishlists
            .Include(w => w.Game)
            .FirstOrDefaultAsync(w => w.UserId == userId && w.GameId == gameId);
    }
    public async Task AddAsync(UserWishlist wishlist)
    {
        await _context.UserWishlists.AddAsync(wishlist);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(UserWishlist wishlist)
    {
        _context.UserWishlists.Remove(wishlist);
        await _context.SaveChangesAsync();
    }
}
