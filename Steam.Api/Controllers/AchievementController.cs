using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs.AchievementDTOs;
using Steam.Application.Interfaces.Repository;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AchievementController : ControllerBase
{
    private readonly IAchievementRepository _repo;
    private readonly IMapper _mapper;

    public AchievementController(IAchievementRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] AchievementCreateDTO dto, CancellationToken ct)
    {
        var entity = _mapper.Map<Steam.Domain.Model.Achievement>(dto);
        var id = await _repo.AddAsync(entity, ct);
        return Ok(new { id });
    }

    [HttpGet("game/{gameId:int}")]
    public async Task<IActionResult> GetByGame(int gameId, CancellationToken ct)
    {
        var list = await _repo.GetByGameIdAsync(gameId, ct);
        return Ok(list);
    }
}