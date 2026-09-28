using Steam.Application.DTOs.AchievementDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IAchievementService
{
    Task<AchievementDTO> CreateAsync(AchievementCreateDTO dto, CancellationToken ct);
    Task<IEnumerable<AchievementDTO>> GetByGameIdAsync(int gameId, CancellationToken ct);
}