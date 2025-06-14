using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IReviewServices
    {
        Task<List<ReviewResponse>> GetAllAsync();
        Task<ReviewResponse?> GetById(int id);
        Task<Review> Add(int movieId,ReviewRequest review);
        Task<bool> Delete(int id);
        Task<bool> Update(ReviewRequest reviewRequest, int id);
    }
}
