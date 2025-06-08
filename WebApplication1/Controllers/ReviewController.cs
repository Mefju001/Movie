using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
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
        [HttpPost]
        public async Task<IActionResult> Add(int movieId,ReviewRequest reviewRequest)
        {
            var reviews = await services.Add(movieId, reviewRequest);
            return CreatedAtAction(nameof(GetById), new {id=reviews.Id},reviews);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await services.GetById(id));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedReview = await services.Delete(id);
            if(!deletedReview)return NotFound();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id,Review review)
        {
            var updatedReview = await services.Update(review, id);
            if(!updatedReview) return NotFound();
            return NoContent();

        }
    }
}
