using CourseNet.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Tests
{
    public class InstructorServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetDb" + Guid.NewGuid()).Options;
            context = new CourseNetDbContext(dbOptions);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}