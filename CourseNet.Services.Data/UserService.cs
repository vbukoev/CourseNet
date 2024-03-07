using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;

namespace CourseNet.Services.Data
{
    public class UserService : IUserService
    {
        private readonly CourseNetDbContext context;

        public UserService(CourseNetDbContext context)
        {
            this.context = context;
        }


    }
}
