using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync(CancellationToken ct);
    Task<Genre?> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<Genre>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken ct);
}