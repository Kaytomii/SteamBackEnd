using AutoMapper;
using Steam.Application.DTOs.MediaDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _repo;
    private readonly IMapper _mapper;

    public MediaService(IMediaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<MediaDTO> CreateAsync(MediaCreateDTO dto, CancellationToken ct)
    {
        var media = _mapper.Map<Media>(dto);
        await _repo.AddAsync(media, ct);
        return _mapper.Map<MediaDTO>(media);
    }

    public async Task<IEnumerable<MediaDTO>> GetByGameIdAsync(int gameId, CancellationToken ct)
    {
        var media = await _repo.GetByGameIdAsync(gameId, ct);
        return _mapper.Map<IEnumerable<MediaDTO>>(media);
    }
}