﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> Add(int userId, int movieId,ReviewRequest reviewRequest)
        {
            var reviews = await services.Add(userId, movieId, reviewRequest);
            return CreatedAtAction(nameof(GetById), new {id=reviews.Id},reviews);

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
