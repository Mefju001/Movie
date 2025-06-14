using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mime;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
namespace WebApplication1.Services.Impl
{
    public class MovieServices : IMovieServices
    {
        private readonly AppDbContext _context;


        public MovieServices(AppDbContext context)
        {
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

        public async Task<List<MovieResponse>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.genre)
                .Include(m => m.director)
                .Include(m => m.reviews)
                .ToListAsync();
            return movies.Select(MovieMapping.ToResponse).ToList();
        }
        public async Task<List<MovieResponse>> GetMovies(string? name, string? genreName, string? directorName, int? movieId)
        {
            var query = _context.Movies
                .Include(m => m.genre)
                .Include(m => m.director)
                .Include(m => m.reviews)
                .AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.title.Contains(name));
            }
            if (!string.IsNullOrEmpty(genreName))
            {
                query = query.Where(m=>m.genre.name.Contains(genreName));
            }
            if (!string.IsNullOrEmpty(directorName))
            {
                query = query.Where(m=>m.director.name.Contains(directorName));
            }
            if (movieId.HasValue)
            {
                query = query.Where(m=>m.Id == movieId.Value);
            }
            var movies = await query.ToListAsync();
            return movies.Select(MovieMapping.ToResponse).ToList();
        }
        public async Task<MovieResponse?> GetById(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.genre)
                .Include(m => m.director)
                .Include(m => m.reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return null;
            return MovieMapping.ToResponse(movie);
        }

        public async Task<bool> Update(MovieRequest updatedMovie,int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;
            var existingDirector = await _context.Directors
                .FirstOrDefaultAsync(d =>
                    d.name == updatedMovie.Director.Name &&
                    d.surname == updatedMovie.Director.Surname);

            if (existingDirector != null)
            {
                movie.director = existingDirector;
            }
            else
            {
                movie.director = new Director
                {
                    name = updatedMovie.Director.Name,
                    surname = updatedMovie.Director.Surname
                };
            }

            var existingGenre = await _context.Genres
                .FirstOrDefaultAsync(g => g.name == updatedMovie.Genre.name);

            movie.genre = existingGenre ?? new Genre
            {
                name = updatedMovie.Genre.name
            };

            movie.title = updatedMovie.Title;
            movie.description = updatedMovie.Description;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}