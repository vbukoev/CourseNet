using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Instructor;
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
        public async Task HasAppliedCoursesByUserIdAsyncShouldReturnFalseWhenHasNotAppliedCourses()
        {
            string nonExistingInstructorUserId = StudentUser.Id.ToString();

            bool result = await instructorService.HasAppliedCoursesByUserIdAsync(nonExistingInstructorUserId);

            Assert.IsFalse(result);
        }
        
        [Test]
        public async Task CreateShouldCreateInstructor()
        {
            string userId = Guid.NewGuid().ToString();
            var model = new BecomeInstructorFormModel
            {
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "+359123456789",
                Email = ""
            };

            await instructorService.Create(userId, model);
        }
        
        [Test]
        public async Task GetInstructorIdByUserIdShouldReturnInstructorId()
        {
            string userId = InstructorUser.Id.ToString();

            string result = await instructorService.GetInstructorIdByUserId(userId);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetInstructorIdByUserIdShouldReturnNullWhenInstructorNotExists()
        {
            string userId = StudentUser.Id.ToString();

            string result = await instructorService.GetInstructorIdByUserId(userId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task HasCourseWithIdAsyncShouldReturnTrueWhenHasCourse()
        {
            string userId = InstructorUser.Id.ToString();
            string courseId = DatabaseSeeder.Course.Id.ToString();

            bool result = await instructorService.HasCourseWithIdAsync(userId, courseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasCourseWithIdAsyncShouldReturnFalseWhenHasNotCourse()
        {
            string userId = InstructorUser.Id.ToString();
            string courseId = Guid.NewGuid().ToString();

            bool result = await instructorService.HasCourseWithIdAsync(userId, courseId);

            Assert.IsFalse(result);
        }
    }
}