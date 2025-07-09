using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WebApplication1.DTO.Request;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly AuthService authService;
        private readonly IUserServices userServices;
        private readonly ILikedMovieServices likedMovieServices;
        public UserController(IUserServices userServices,AuthService authService, ILikedMovieServices likedMovieServices)
        {
            this.userServices = userServices;
            this.authService = authService;
            this.likedMovieServices = likedMovieServices;
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await userServices.GetAllAsync());
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await userServices.GetById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("/{name}")]
        public async Task<IActionResult> GetBy(string name)
        {
            return Ok(await userServices.GetBy(name));
        }
       // [Authorize(Roles = "Admin")]
        [HttpGet("/Liked")]
        public async Task<IActionResult> GetLikedMovies()
        {
            return Ok(await likedMovieServices.GetAllAsync());
        }
        [HttpPost("/Liked")]
        public async Task<IActionResult> AddLikedMovie([FromBody] LikedMovieRequest likedMovie)
        {
            return Ok(await likedMovieServices.Add(likedMovie));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPatch("ChangePassword")]
        public async Task<IActionResult>ChangePassword(string newPassword, string confirmPassword, string oldPassword)
        {
            var stringUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (stringUserId == null)
            {
                return Unauthorized();
            }
            int userId = parse(stringUserId);
            return Ok(await userServices.changePassword(newPassword,confirmPassword,oldPassword,userId));
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPatch("/ChangeDetails")]
        public async Task<IActionResult> ChangeDetails(UserDetailsRequest userDetailsRequest)
        {
            var stringUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (stringUserId == null)
            {
                return Unauthorized();
            }
            int userId = parse(stringUserId);
            return Ok(await userServices.changedetails(userId, userDetailsRequest));
        }
    }
}
