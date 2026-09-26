using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs.SystemRequirementsDTOs;
using Steam.Application.Interfaces.Repository;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemRequirementsController : ControllerBase
{
    private readonly ISystemRequirementsRepository _repo;
    private readonly IMapper _mapper;

    public SystemRequirementsController(ISystemRequirementsRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] SystemRequirementsCreateDTO dto, CancellationToken ct)
    {
        var entity = _mapper.Map<Steam.Domain.Model.SystemRequirements>(dto);
        var id = await _repo.AddAsync(entity, ct);
        return Ok(new { id });
    }

    [HttpGet("game/{gameId:int}")]
    public async Task<IActionResult> GetByGame(int gameId, CancellationToken ct)
    {
        var req = await _repo.GetByGameIdAsync(gameId, ct);
        if (req == null) return NotFound();
        return Ok(req);
    }
}