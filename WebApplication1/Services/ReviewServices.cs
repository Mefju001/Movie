
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly AppDbContext _context;
        public ReviewServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Review> Add(int userId,int MovieId, ReviewRequest reviewRequest)
        {

            var review = new Review 
            {
                Comment = reviewRequest.Comment,
                Rating = reviewRequest.Rating,
                MovieId = MovieId,
                UserId = userId
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> Delete(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ReviewResponse>> GetAllAsync()
        {
            var reviews = await _context.Reviews
                .Include(r=>r.User)
                .Include(r=>r.Movie)
                .ToListAsync();
            foreach (var r in reviews)
            {
                Console.WriteLine($"Id:{r.Id} MovieId:{r.MovieId} UserId:{r.UserId} Username:{r.User?.username ?? "NULL"} Comment:{r.Comment} Rating:{r.Rating}");

            }
            return reviews.Select(ReviewMapping.ToResponse).ToList();
        }

        public async Task<ReviewResponse?> GetById(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review != null)return ReviewMapping.ToResponse(review);
            return null;
        }

        public async Task<bool> Update(ReviewRequest review, int id)
        {
            var fReview = _context.Reviews.FindAsync(id);
            if (review == null) return false;
            //review.SetReview(review);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
