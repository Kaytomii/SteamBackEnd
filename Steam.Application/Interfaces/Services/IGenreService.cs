using Steam.Application.DTOs.GenreDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreDTO>> GetAllAsync(CancellationToken ct);
}