
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly AppDbContext _context;
        public ReviewServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Review> Add(int MovieId, ReviewRequest reviewRequest)
        {
            var review = new Review 
            {
                Comment = reviewRequest.Comment,
                Rating = reviewRequest.Rating,
                MovieId = MovieId
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
            var reviews = await _context.Reviews.ToListAsync();
            return reviews.Select(ReviewMapping.ToResponse).ToList();
        }

        public async Task<ReviewResponse?> GetById(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review != null)return ReviewMapping.ToResponse(review);
            return null;
        }

        public async Task<bool> Update(Review review, int id)
        {
            var fReview = _context.Reviews.FindAsync(id);
            if (review == null) return false;
            review.SetReview(review);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
