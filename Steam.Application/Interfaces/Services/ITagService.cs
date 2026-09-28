using Steam.Application.DTOs.TagDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface ITagService
{
    Task<IEnumerable<TagDTO>> GetAllAsync(CancellationToken ct);
}
