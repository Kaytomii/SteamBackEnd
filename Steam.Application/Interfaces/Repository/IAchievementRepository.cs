using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IAchievementRepository
{
    Task<Guid?> AddAsync(Achievement achievement, CancellationToken ct);
    Task<IEnumerable<Achievement>> GetByGameIdAsync(Guid gameId, CancellationToken ct);
    Task<Achievement?> GetByIdAsync(Guid id, CancellationToken ct);
}