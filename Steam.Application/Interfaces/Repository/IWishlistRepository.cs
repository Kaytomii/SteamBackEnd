using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IWishlistRepository
{
    Task<List<UserWishlist>> GetByUserIdAsync(Guid userId);
    Task<UserWishlist?> GetAsync(Guid userId, Guid gameId);
    Task AddAsync(UserWishlist wishlist);
    Task RemoveAsync(UserWishlist wishlist);
}