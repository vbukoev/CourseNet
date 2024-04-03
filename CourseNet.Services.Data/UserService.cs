using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class UserService : IUserService
    {
        private readonly CourseNetDbContext context;

        public UserService(CourseNetDbContext context)
        {
            this.context = context;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            CourseUser? user = await context
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public Task<string> GetFullNameByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

