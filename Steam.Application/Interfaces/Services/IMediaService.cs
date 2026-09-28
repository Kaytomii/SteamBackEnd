using Steam.Application.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IMediaService
{
    Task<MediaDTO> CreateAsync(MediaCreateDTO dto, CancellationToken ct);
    Task<IEnumerable<MediaDTO>> GetByGameIdAsync(int gameId, CancellationToken ct);
}