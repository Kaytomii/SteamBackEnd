using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs.MediaDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediaService _service;

    public MediaController(IMediaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MediaCreateDTO dto, CancellationToken ct)
    {
        var media = await _service.CreateAsync(dto, ct);
        return Created($"api/media/{media.Id}", media);
    }

    [HttpGet("game/{gameId:int}")]
    public async Task<IActionResult> GetByGameId(int gameId, CancellationToken ct)
    {
        return Ok(await _service.GetByGameIdAsync(gameId, ct));
    }
}