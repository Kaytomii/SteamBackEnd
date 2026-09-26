using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface ISystemRequirementsRepository
{
    Task<int?> AddAsync(SystemRequirements req, CancellationToken ct);
    Task<SystemRequirements?> GetByGameIdAsync(int gameId, CancellationToken ct);
}