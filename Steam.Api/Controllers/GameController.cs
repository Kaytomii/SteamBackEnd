using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs.GameDTOs;
using Steam.Application.Interfaces.Repository;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _repo;
    private readonly IMapper _mapper;

    public GameController(IGameRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] GameCreateDto dto, CancellationToken ct)
    {
        var game = _mapper.Map<Steam.Domain.Model.Game>(dto);
        var id = await _repo.AddAsync(game, ct);
        return Ok(new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var list = await _repo.GetAllAsync(ct);
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var game = await _repo.GetByIdAsync(id, ct);
        if (game == null) return NotFound();
        return Ok(game);
    }
}