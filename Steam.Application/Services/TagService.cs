using AutoMapper;
using Steam.Application.DTOs.TagDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _repo;
    private readonly IMapper _mapper;

    public TagService(ITagRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TagDTO>> GetAllAsync(CancellationToken ct)
    {
        var tags = await _repo.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<TagDTO>>(tags);
    }
}