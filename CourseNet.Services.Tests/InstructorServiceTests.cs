using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;
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
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            instructorService = new InstructorService(context);
        }

        [Test]
        public async Task InstructorExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingInstructorUserId = InstructorUser.Id.ToString();

            bool result = await instructorService.InstructorExistsByUserId(existingInstructorUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task InstructorExistsByUserIdAsyncShouldReturnFalseWhenNotExists()
        {
            string nonExistingInstructorUserId = StudentUser.Id.ToString();

            bool result = await instructorService.InstructorExistsByUserId(nonExistingInstructorUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task InstructorExistsByPhoneNumberAsyncShouldReturnTrueWhenExists()
        {
            string existingInstructorPhoneNumber = "+359123456789";

            bool result = await instructorService.InstructorExistsByPhoneNumber(existingInstructorPhoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task InstructorExistsByPhoneNumberAsyncShouldReturnFalseWhenNotExists()
        {
            string nonExistingInstructorPhoneNumber = "+359987654321";

            bool result = await instructorService.InstructorExistsByPhoneNumber(nonExistingInstructorPhoneNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasAppliedCoursesByUserIdAsyncShouldReturnTrueWhenHasAppliedCourses()
        {
            string existingInstructorUserId = "120206E2-D1E9-4B04-BF2C-943FE9A1793D";

            bool result = await instructorService.HasAppliedCoursesByUserIdAsync(existingInstructorUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasAppliedCoursesByUserIdAsyncShouldReturnFalseWhenHasNotAppliedCourses()
        {
            string nonExistingInstructorUserId = StudentUser.Id.ToString();

            bool result = await instructorService.HasAppliedCoursesByUserIdAsync(nonExistingInstructorUserId);

            Assert.IsFalse(result);
        }
    }
}