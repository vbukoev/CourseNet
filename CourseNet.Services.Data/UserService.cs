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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            CourseUser? user = await this.context
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        //public async Task<IEnumerable<UserViewModel>> AllAsync()
        //{
        //    List<UserViewModel> allUsers = await this.context
        //        .Users
        //        .Select(u => new UserViewModel()
        //        {
        //            Id = u.Id.ToString(),
        //            Email = u.Email,
        //            FullName = u.FirstName + " " + u.LastName
        //        })
        //        .ToListAsync();
        //    foreach (UserViewModel user in allUsers)
        //    {
        //        Instructor? agent = this.context
        //            .Instructors
        //            .FirstOrDefault(a => a.UserId.ToString() == user.Id);
        //        if (agent != null)
        //        {
        //            user.PhoneNumber = agent.PhoneNumber;
        //        }
        //        else
        //        {
        //            user.PhoneNumber = string.Empty;
        //        }
        //    }

        //    return allUsers;
        //}
    }
}

