using Steam.Application.DTOs;
using Steam.Application.DTOs.AuthDTOs;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using Steam.Domain.Enum;
using Steam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;
    private readonly IJWTService _jwt;

    public AuthService(IAuthRepository repo, IJWTService jwt)
    {
        _repo = repo;
        _jwt = jwt;
    }

    public async Task<TokenResponseDTO> LoginExternalAsync(ExternalAuthDTO dto, CancellationToken ct)
    {
        var user = await _repo.GetByEmailAsync(dto.Email, ct);

        if (user == null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Username = dto.Name,
                Role = UserRole.User
            };

            await _repo.AddUserAsync(user, ct);
        }

        var access = _jwt.GenerateAccessToken(user);
        var refresh = _jwt.CreateRefreshToken(user.Id);

        await _repo.SaveRefreshTokenAsync(refresh, ct);

        return new TokenResponseDTO
        {
            AccessToken = access,
            RefreshToken = refresh.Token,
            ExpiresAt = refresh.ExpiresAt
        };
    }

    public async Task<TokenResponseDTO?> RefreshAsync(string refreshToken, CancellationToken ct)
    {
        var token = await _repo.GetRefreshTokenAsync(refreshToken, ct);
        if (token == null || token.ExpiresAt < DateTime.UtcNow)
            return null;

        var user = await _repo.GetByIdAsync(token.UserId, ct);
        if (user == null)
            return null;

        var access = _jwt.GenerateAccessToken(user);
        var newRefresh = _jwt.CreateRefreshToken(user.Id);

        await _repo.SaveRefreshTokenAsync(newRefresh, ct);

        return new TokenResponseDTO
        {
            AccessToken = access,
            RefreshToken = newRefresh.Token,
            ExpiresAt = newRefresh.ExpiresAt
        };
    }
}