using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.DTOs.RefreshTokenDTOs;

public class RefreshTokenDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}