using Steam.Application.DTOs.ProviderDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IProviderService
{
    Task<IEnumerable<ProviderDTO>> GetAllAsync(CancellationToken ct);
}