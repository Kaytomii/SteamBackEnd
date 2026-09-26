using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllAsync(CancellationToken ct);
    Task<Tag?> GetByIdAsync(int id, CancellationToken ct);
}