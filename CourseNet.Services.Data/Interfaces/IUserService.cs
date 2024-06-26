﻿using CourseNet.Web.ViewModels.User;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
