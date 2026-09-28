using AutoMapper;
using Steam.Application.DTOs.GenreDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repo;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreDTO>> GetAllAsync(CancellationToken ct)
    {
        var genres = await _repo.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<GenreDTO>>(genres);
    }
}