using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.DTO.Request;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

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
        private int parse(string String)
        {
            int id = int.Parse(String);
            if (int.TryParse(String, out int userId))
            {
                return userId;
            }
            else
                throw new Exception();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> Add(int movieId,ReviewRequest reviewRequest)
        {
            var stringUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (stringUserId == null)
            {
                return Unauthorized();
            }
            int userId = parse(stringUserId);
            var (id, response) = await services.Add(userId, movieId, reviewRequest);
            return Ok(CreatedAtAction(nameof(GetById), new {id=id},response));

        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await services.GetById(id));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedReview = await services.Delete(id);
            if(!deletedReview)return NotFound();
            return NoContent();
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id,ReviewRequest reviewRequest)
        {
            var updatedReview = await services.Update(reviewRequest, id);
            if(!updatedReview) return NotFound();
            return NoContent();

        }
    }
}
