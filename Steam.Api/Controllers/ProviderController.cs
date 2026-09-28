using Microsoft.AspNetCore.Mvc;
using Steam.Application.Interfaces.Services;

namespace Steam.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProviderController : ControllerBase
{
    private readonly IProviderService _service;

    public ProviderController(IProviderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetAllAsync(ct));
    }
}