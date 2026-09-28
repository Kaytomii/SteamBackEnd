using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs;
using Steam.Application.DTOs.AuthDTOs;
using Steam.Application.Interfaces;
using Steam.Application.Interfaces.Services;

namespace Steam.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("external-login")]
    public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDTO dto, CancellationToken ct)
    {
        var result = await _auth.LoginExternalAsync(dto, ct);
        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequestDTO dto, CancellationToken ct)
    {
        var result = await _auth.RefreshAsync(dto.RefreshToken, ct);
        return result == null ? Unauthorized() : Ok(result);
    }
}