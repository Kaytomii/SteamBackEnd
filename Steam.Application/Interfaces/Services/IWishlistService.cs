using Steam.Application.DTOs.GameDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IWishlistService
{
    Task<IEnumerable<GameListItemDTO>> GetWishlistAsync();
    Task<GameListItemDTO?> AddGameToWishlistAsync(Guid gameId);
    Task RemoveGameFromWishlistAsync(Guid gameId);
}
