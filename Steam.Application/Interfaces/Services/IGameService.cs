using Steam.Application.DTOs.GameDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IGameService
{
    Task<GameDTO> CreateAsync(GameCreateDTO dto, CancellationToken ct);
    Task<GameDTO?> UpdateAsync(int id, GameUpdateDTO dto, CancellationToken ct);
    Task<GameDTO?> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<GameListItemDTO>> GetAllAsync(CancellationToken ct);
}