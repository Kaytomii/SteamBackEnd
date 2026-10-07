using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Steam.Application.Interfaces.Services;

namespace Steam.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : Controller
    {
        private readonly IWishlistService _service;

        public WishlistController(IWishlistService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserWishlist()
        {
            var wishlist = await _service.GetWishlistAsync();
            return Ok(wishlist);
        }
        [HttpPost("{gameId:int}")]
        public async Task<IActionResult> AddGameToWishlist(int gameId)
        {
            await _service.AddGameToWishlistAsync(gameId);
            return Ok();
        }
        [HttpDelete("{gameId:int}")]
        public async Task<IActionResult> RemoveGameFromWishlist(int gameId)
        {
            await _service.RemoveGameFromWishlistAsync(gameId);
            return Ok();
        }
    }
}
