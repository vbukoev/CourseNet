using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;
namespace CourseNet.Services.Tests
{
    public class CourseServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private CourseService courseService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            courseService = new CourseService(context);
        }

        [Test]
        public async Task GetAllCoursesAsyncShouldReturnAllCourses()
        {
            var courses = await courseService.GetAllCoursesAsync();
            var coursesInDb = context.Courses.Count();
            Assert.AreEqual(coursesInDb, courses.Count());
        }

        [Test]
        public async Task GetAllCoursesAsyncShouldNotReturnAllCourses()
        {
            var courses = await courseService.GetAllCoursesAsync();
            var coursesInDb = context.Courses.Count();
            Assert.AreNotEqual(coursesInDb + 1, courses.Count());
        }


        [Test]
        public async Task CreateCourseAndReturnIdAsyncShouldReturnId()
        {
            var courseFormViewModel = new CourseFormViewModel
            {
                Title = "Test Course",
                Description = "Test Description",
                CategoryId = 1,
                EndDate = DateTime.UtcNow.AddDays(10).ToString(),
                Price = 100,
            };

            var instructorId = InstructorUser.Id.ToString();

            var courseId = await courseService.CreateCourseAndReturnIdAsync(courseFormViewModel, instructorId);

            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            if (courseId != null) 
                Assert.AreEqual(courseId, course.Id);
        }
        
    }
}