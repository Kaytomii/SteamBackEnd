using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IMediaRepository
{
    Task<int?> AddAsync(Media media, CancellationToken ct);
    Task<IEnumerable<Media>> GetByGameIdAsync(int gameId, CancellationToken ct);
    Task<Media?> GetByIdAsync(int id, CancellationToken ct);
}