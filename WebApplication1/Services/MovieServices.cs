using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
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

        public async Task<Movie> Add(Movie movie)
        {
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