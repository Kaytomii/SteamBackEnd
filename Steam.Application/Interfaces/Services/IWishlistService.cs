using System;
using System.Collections.Generic;
using System.Text;
using Steam.Application.DTOs.GameDTOs;

namespace Steam.Application.Interfaces.Services;

public interface IWishlistService
{
    Task<IEnumerable<GameListItemDTO>> GetWishlistAsync();
    Task<GameListItemDTO?> AddGameToWishlistAsync(int gameId);
    Task RemoveGameFromWishlistAsync(int gameId);
}
