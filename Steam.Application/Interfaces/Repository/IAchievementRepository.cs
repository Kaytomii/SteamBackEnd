using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IAchievementRepository
{
    Task<int?> AddAsync(Achievement achievement, CancellationToken ct);
    Task<IEnumerable<Achievement>> GetByGameIdAsync(int gameId, CancellationToken ct);
    Task<Achievement?> GetByIdAsync(int id, CancellationToken ct);
}