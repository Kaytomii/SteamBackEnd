using AutoMapper;
using Steam.Application.DTOs.GameDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repo;
    private readonly IGenreRepository _genreRepo;
    private readonly ITagRepository _tagRepo;
    private readonly IMapper _mapper;

    public GameService(
        IGameRepository repo,
        IGenreRepository genreRepo,
        ITagRepository tagRepo,
        IMapper mapper)
    {
        _repo = repo;
        _genreRepo = genreRepo;
        _tagRepo = tagRepo;
        _mapper = mapper;
    }

    public async Task<GameDTO> CreateAsync(GameCreateDTO dto, CancellationToken ct)
    {
        var game = new Game
        {
            Name = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            ReleaseDate = DateTime.UtcNow,
            DeveloperId = dto.DeveloperId
        };

        foreach (var item in dto.Media)
        {
            game.Media.Add(new Media
            {
                Url = item.Url,
                Type = item.Type,
                FileName = item.FileName,
                Size = item.Size
            });
        }

        // Здесь же формируются GameGenres, GameTags,
        // SystemRequirements и Achievements.

        await _repo.AddAsync(game, ct);

        return _mapper.Map<GameDTO>(game);
    }

    public async Task<GameDTO?> UpdateAsync(int id, GameUpdateDTO dto, CancellationToken ct)
    {
        var game = await _repo.GetByIdAsync(id, ct);
        if (game == null)
            return null;

        _mapper.Map(dto, game);
        await _repo.UpdateAsync(game, ct);

        return _mapper.Map<GameDTO>(game);
    }

    public async Task<GameDTO?> GetByIdAsync(int id, CancellationToken ct)
    {
        var game = await _repo.GetByIdAsync(id, ct);
        return game == null ? null : _mapper.Map<GameDTO>(game);
    }

    public async Task<IEnumerable<GameListItemDTO>> GetAllAsync(CancellationToken ct)
    {
        var games = await _repo.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<GameListItemDTO>>(games);
    }
}