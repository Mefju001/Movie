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
        [HttpGet("movies")]
        public async Task<IActionResult>GetMovies([FromQuery] string?name, [FromQuery] string? genreid, [FromQuery] string? directorid, [FromQuery]int? movieId)
        {
            var movies = await _services.GetMovies(name,genreid,directorid,movieId);
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
        public async Task<IActionResult> Create(MovieRequest movie)
        {
            var created = await _services.Add(movie);
            return Ok(created);//CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _services.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, MovieRequest movieRequest)
        {
            var updatedMovie = await _services.Update(movieRequest, id);
            if (!updatedMovie) return NotFound();
            return NoContent();

        }
    }
}