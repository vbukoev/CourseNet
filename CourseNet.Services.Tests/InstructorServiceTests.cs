using CourseNet.Data;
using CourseNet.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CourseNet.Services.Tests
{
    public class InstructorServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private InstructorService instructorService;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetDB2024" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions, false);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            instructorService = new InstructorService(context);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}