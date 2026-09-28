using AutoMapper;
using Steam.Application.DTOs.AchievementDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class AchievementService : IAchievementService
{
    private readonly IAchievementRepository _repo;
    private readonly IMapper _mapper;

    public AchievementService(IAchievementRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<AchievementDTO> CreateAsync(AchievementCreateDTO dto, CancellationToken ct)
    {
        var achievement = _mapper.Map<Achievement>(dto);
        await _repo.AddAsync(achievement, ct);
        return _mapper.Map<AchievementDTO>(achievement);
    }

    public async Task<IEnumerable<AchievementDTO>> GetByGameIdAsync(int gameId, CancellationToken ct)
    {
        var achievements = await _repo.GetByGameIdAsync(gameId, ct);
        return _mapper.Map<IEnumerable<AchievementDTO>>(achievements);
    }
}