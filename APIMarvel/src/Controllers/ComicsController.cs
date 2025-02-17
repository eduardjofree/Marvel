using APIMarvel.src.Application.Services;
using APIMarvel.src.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMarvel.src.Controllers
{
    [Route("api/Comics")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicService _comicService;

        public ComicsController(ComicService comicService)
        {
            _comicService = comicService;
        }

        [HttpGet("GetAllComics")]
        [Authorize]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _comicService.GetAllComicsAsync();
            return Ok(comics);
        }

        [HttpGet("GetComicById/{id}")]
        [Authorize]
        public async Task<ActionResult<Comic>> GetComicById(int id)
        {
            var comic = await _comicService.GetComicByIdAsync(id);
            return Ok(comic);
        }
    }
}
