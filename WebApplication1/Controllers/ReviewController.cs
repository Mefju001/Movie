using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController:ControllerBase
    {
        private readonly IReviewServices services;
        public ReviewController(IReviewServices services)
        {
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var reviews = await services.GetAllAsync();
            return Ok(reviews);

        }
    }
}
