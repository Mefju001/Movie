using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Services.Impl;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _services;

        public MovieController(IMovieServices services)
        {
            _services = services;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _services.GetAllAsync();
            return Ok(movies);
        }
        [AllowAnonymous]
        [HttpGet("sortBy/{sort}")]
        public async Task<IActionResult> GetSortAll(string sort)
        {
            var movies = await _services.GetSortAll(sort);
            return Ok(movies);
        }
        [AllowAnonymous]
        [HttpGet("FilterBy")]
        public async Task<IActionResult>GetMovies([FromQuery] string?name, [FromQuery] string? genreName, [FromQuery] string? directorName, [FromQuery]int? movieId)
        {
            var movies = await _services.GetMovies(name, genreName, directorName, movieId);
            return Ok(movies);
        }
        [AllowAnonymous]
        [HttpGet("byAvarage")]
        public async Task<IActionResult> GetMoviesByAvarage()
        {
            var movies = await _services.GetMoviesByAvrRating();
            return Ok(movies);
        }
        [AllowAnonymous]
        [HttpGet("id/{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var movie = await _services.GetById(id);
            return Ok(movie);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Upsert(int? id,MovieRequest movie)
        {
            var created = await _services.Upsert(id,movie);
            if(id is null)
                return Ok(CreatedAtAction(nameof(GetById), new { id = created.movieId }, created.response));
            return Ok(created.response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _services.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}