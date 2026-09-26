using Steam.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(string accessToken, string refreshToken)> ExternalLoginAsync(ExternalAuthDTO dto, CancellationToken ct);
    Task<string?> RefreshAsync(string refreshToken, CancellationToken ct);
}