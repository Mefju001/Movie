﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO.Mapping;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class LikedMovieServices(AppDbContext context):ILikedMovieServices
    {
        private readonly AppDbContext AppDbContext = context;

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LikedMovieResponse>> GetAllAsync()
        {
            var likedMovies = await AppDbContext.UserMovieLike
                .Include(uml => uml.movie)
                    .ThenInclude(m => m.genre)
                .Include(uml => uml.movie)
                    .ThenInclude(m=>m.director)
                .Include(uml => uml.movie)
                    .ThenInclude(m => m.reviews)
                    .ThenInclude(r=>r.User)
                .Include(uml => uml.user)
                    .ThenInclude(u=>u.UserRoles)
                        .ThenInclude(ur=>ur.Role)
                .ToListAsync();
            return likedMovies.Select(LikedMovieMapping.ToResponse).ToList();
        }

        public Task<LikedMovieResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(int movieId, LikedMovieResponse response)> Add(LikedMovieRequest movie)
        {
            throw new NotImplementedException();
        }
    }
}
