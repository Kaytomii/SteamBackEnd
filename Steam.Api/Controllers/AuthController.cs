using Microsoft.AspNetCore.Mvc;
using Steam.Application.DTOs;
using Steam.Application.Interfaces;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("external")]
    public async Task<IActionResult> External([FromBody] ExternalAuthDTO dto, CancellationToken ct)
    {
        var (access, refresh) = await _authService.ExternalLoginAsync(dto, ct);
        Response.Cookies.Append("refresh_token", refresh, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(30)
        });
        return Ok(new { access_token = access });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(CancellationToken ct)
    {
        var refresh = Request.Cookies["refresh_token"];
        if (string.IsNullOrEmpty(refresh)) return Unauthorized();
        var newAccess = await _authService.RefreshAsync(refresh, ct);
        if (newAccess == null) return Unauthorized();
        return Ok(new { access_token = newAccess });
    }
}