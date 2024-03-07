using CourseNet.Data;

namespace CourseNet.Services.Data.Interfaces
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
