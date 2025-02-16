using APIMarvel.src.Application.DTOs;
using APIMarvel.src.Application.Services;
using APIMarvel.src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIMarvel.src.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteComicsController : ControllerBase
    {
        private readonly FavoriteComicService _favoriteComicService;

        public FavoriteComicsController(FavoriteComicService favoriteComicService)
        {
            _favoriteComicService = favoriteComicService;
        }

        [HttpGet("GetFavorites")]
        public async Task<ActionResult<List<FavoriteComic>>> GetFavorites(int userId)
        {
            var favorites = await _favoriteComicService.GetFavoritesByUserAsync(userId);

            if (favorites == null || favorites.Count == 0)
                return NotFound("No tienes cómics favoritos.");

            return Ok(favorites);
        }

        [HttpPost("AddFavorites")]
        public async Task<ActionResult> AddToFavorites([FromBody] RequestFavoriteComic favoriteComic)
        {
            int userId = favoriteComic.UserId;
            int comicId = favoriteComic.ComicId;
            var result = await _favoriteComicService.AddFavoriteAsync(userId, comicId);

            if (!result)
                return BadRequest("El cómic ya está en tu lista de favoritos.");

            return Ok(new { message = "Cómic agregado a favoritos." });
        }

        [HttpDelete("{comicId}")]
        public async Task<ActionResult> RemoveFromFavorites(int userId, int comicId)
        {
            var result = await _favoriteComicService.RemoveFavoriteAsync(userId, comicId);

            if (!result)
                return NotFound("El cómic no está en tu lista de favoritos.");

            return Ok(new { message = "Cómic eliminado de favoritos." });
        }
    }
}
