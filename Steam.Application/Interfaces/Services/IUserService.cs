using Steam.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<UserDTO> CreateAsync(UserCreateDTO dto, CancellationToken ct);
    Task<UserDTO?> UpdateAvatarAsync(Guid id, string avatarUrl, CancellationToken ct);
}