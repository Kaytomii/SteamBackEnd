using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs.MediaDTOs;
using Steam.Application.Interfaces.Repository;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediaRepository _repo;
    private readonly IMapper _mapper;

    public MediaController(IMediaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] MediaCreateDTO dto, CancellationToken ct)
    {
        var media = _mapper.Map<Steam.Domain.Model.Media>(dto);
        var id = await _repo.AddAsync(media, ct);
        return Ok(new { id });
    }

    [HttpGet("game/{gameId:int}")]
    public async Task<IActionResult> GetByGame(int gameId, CancellationToken ct)
    {
        var list = await _repo.GetByGameIdAsync(gameId, ct);
        return Ok(list);
    }
}