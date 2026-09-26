using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Repository;

public interface IProviderRepository
{
    Task<IEnumerable<Provider>> GetAllAsync(CancellationToken ct);
    Task<Provider?> GetByIdAsync(int id, CancellationToken ct);
}