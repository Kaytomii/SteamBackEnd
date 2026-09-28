using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct);
    Task<Game?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(Game game, CancellationToken ct);
    Task UpdateAsync(Game game, CancellationToken ct);
}