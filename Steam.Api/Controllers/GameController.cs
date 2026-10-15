using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Api.Models;
using Steam.Application.DTOs.GameDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _service;

    public GameController(IGameService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetAllAsync(ct));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var game = await _service.GetByIdAsync(id, ct);
        return game == null ? NotFound() : Ok(game);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create(
    [FromForm] GameCreateForm form,
    CancellationToken ct)
    {
        // 1. Проверить форму и количество файлов.
        // 2. Десериализовать GenreIds, TagIds,
        //    SystemRequirements и Achievements из JSON.
        // 3. Сохранить файлы через IFileStorageService.
        // 4. Сформировать GameCreateDTO со списком Media.
        // 5. Вызвать _service.CreateAsync(dto, ct).

        // После успешного создания:
        // return Created(...);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] GameUpdateDTO dto, CancellationToken ct)
    {
        var game = await _service.UpdateAsync(id, dto, ct);
        return game == null ? NotFound() : Ok(game);
    }
}