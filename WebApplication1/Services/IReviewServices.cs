using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IReviewServices
    {
        Task<List<ReviewResponse>> GetAllAsync();
        Task<Review?> GetById(int id);
        Task<Review> Add(Review review);
        Task<bool> Delete(int id);
        Task<bool> Update(Review review, int id);
    }
}
