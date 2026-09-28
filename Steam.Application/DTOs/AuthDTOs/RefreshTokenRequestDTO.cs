using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.AuthDTOs;

public class RefreshTokenRequestDTO
{
    public string RefreshToken { get; set; } = string.Empty;
}