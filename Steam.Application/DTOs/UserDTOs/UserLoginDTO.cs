using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.UserDTOs;

public class UserLoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}