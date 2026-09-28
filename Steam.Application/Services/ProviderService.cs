using AutoMapper;
using Steam.Application.DTOs.ProviderDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _repo;
    private readonly IMapper _mapper;

    public ProviderService(IProviderRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProviderDTO>> GetAllAsync(CancellationToken ct)
    {
        var providers = await _repo.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<ProviderDTO>>(providers);
    }
}