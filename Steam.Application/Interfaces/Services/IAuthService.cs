using Steam.Application.DTOs;
using Steam.Application.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IAuthService
{
    Task<TokenResponseDTO> LoginExternalAsync(ExternalAuthDTO dto, CancellationToken ct);
    Task<TokenResponseDTO?> RefreshAsync(string refreshToken, CancellationToken ct);
}