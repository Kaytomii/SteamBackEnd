using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IGameRepository
{
    Task<int?> AddAsync(Game game, CancellationToken ct);
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct);
    Task<Game?> GetByIdAsync(int id, CancellationToken ct);
}