using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

using static CourseNet.Services.Tests.DatabaseSeeder;
namespace CourseNet.Services.Tests
{
    public class EnrollServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private IEnrollService enrollService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            enrollService = new EnrollService(context);
        }

        [Test]
        public async Task GetAllAsyncShouldReturnAllEnrollments()
        {
            var enrollments = await enrollService.GetAllAsync();

            Assert.AreEqual(0, enrollments.Count());
        }
    }
}
