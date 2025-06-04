using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.Models;
namespace WebApplication1.Services.Impl
{
    public class MovieServices : IMovieServices
    {
        private readonly AppDbContext _context;
        /// <summary>
        /// private readonly MovieMapping _mapper;
        /// </summary>
        /// <param name="context"></param>
        /// <param name="movieMapper"></param>

        public MovieServices(AppDbContext context/*,MovieMapping movieMapper*/)
        {
            //_mapper = movieMapper;
            _context = context;
        }

        public async Task<Movie> Add(MovieRequest movieRequest)
        {
            var movie = new Movie
            {
                title = movieRequest.Title,
                description = movieRequest.Description
            };

            var existingDirector = await _context.Directors
                .FirstOrDefaultAsync(d =>
                    d.name == movieRequest.Director.Name &&
                    d.surname == movieRequest.Director.Surname);

            if (existingDirector != null)
            {
                movie.director = existingDirector;
            }
            else
            {
                movie.director = new Director
                {
                    name = movieRequest.Director.Name,
                    surname = movieRequest.Director.Surname
                };
            }

            var existingGenre = await _context.Genres
                .FirstOrDefaultAsync(g => g.name == movieRequest.Genre.name);

            movie.genre = existingGenre ?? new Genre
            {
                name = movieRequest.Genre.name
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(m => m.genre)
                .Include(m => m.director)
                .Include(m => m.reviews)
                .ToListAsync();
        }

        public async Task<Movie?> GetById(int id)
        {
            return await _context.Movies
                .Include(m => m.genre)
                .Include(m => m.director)
                .Include(m => m.reviews)
                .FirstOrDefaultAsync(m=>m.Id==id);
        }

        public async Task<bool> Update(Movie updatedMovie,int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;
            movie.updateMovie(updatedMovie);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}