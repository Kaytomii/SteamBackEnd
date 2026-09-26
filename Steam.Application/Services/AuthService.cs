using Steam.Application.DTOs;
using Steam.Application.Interfaces.Services;
using Steam.Application.Interfaces.Repository;
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

    public async Task<(string accessToken, string refreshToken)> ExternalLoginAsync(ExternalAuthDTO dto, CancellationToken ct)
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
        var refreshEntity = _jwt.CreateRefreshToken(user.Id);
        await _repo.SaveRefreshTokenAsync(refreshEntity, ct);

        return (access, refreshEntity.Token);
    }

    public async Task<string?> RefreshAsync(string refreshToken, CancellationToken ct)
    {
        var tokenEntity = await _repo.GetRefreshTokenAsync(refreshToken, ct);
        if (tokenEntity == null || tokenEntity.ExpiresAt < DateTime.UtcNow) return null;
        var user = await _repo.GetByIdAsync(tokenEntity.UserId, ct);
        if (user == null) return null;
        return _jwt.GenerateAccessToken(user);
    }
}