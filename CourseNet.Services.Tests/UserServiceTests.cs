using CourseNet.Data;
using CourseNet.Services.Data;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;

namespace CourseNet.Services.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private UserService userService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            userService = new UserService(context);
        }

        [Test]
        public async Task GetFullNameByEmailAsyncShouldNotReturnFullName()
        {
            var existingUserEmail = context.Users.First().Email;

            var fullName = await userService.GetFullNameByEmailAsync(existingUserEmail);

            Assert.AreNotEqual(fullName + "1", fullName);
        }

        [Test]
        public async Task GetFullNameByIdAsyncShouldNotReturnFullName()
        {
            var existingUserId = context.Users.First().Id.ToString();

            var fullName = await userService.GetFullNameByIdAsync(existingUserId);

            Assert.AreNotEqual(fullName + "1", fullName);
        }

        [Test]
        public async Task GetAllUsersAsyncShouldReturnAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            Assert.AreEqual(context.Users.Count(), users.Count());
        }

        [Test]
        public async Task GetAllUsersAsyncShouldNotReturnAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            Assert.AreNotEqual(users.Count() + 1, users.Count());
        }
    }
}
