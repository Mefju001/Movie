﻿using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse?> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> changePassword(string newPassword,string confirmPassword,string oldPassword,int userId);
        Task<bool> changedetails(int userId,UserDetailsRequest userDetailsRequest);
        Task<bool> Register(UserRequest userRequest);
        Task<List<UserResponse>> GetBy(string name);
    }
}
