using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.UserDTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
}