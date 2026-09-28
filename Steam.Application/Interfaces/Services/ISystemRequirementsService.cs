using Steam.Application.DTOs.SystemRequirementsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface ISystemRequirementsService
{
    Task<SystemRequirementsDTO> CreateAsync(SystemRequirementsCreateDTO dto, CancellationToken ct);
    Task<SystemRequirementsDTO?> GetByGameIdAsync(int gameId, CancellationToken ct);
}