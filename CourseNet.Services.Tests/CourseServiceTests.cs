using CourseNet.Data;
using CourseNet.Data.Models.Entities.Enums;
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
                EndDate = "29/04/2024 15:21",
                ImagePath = "https://www.test.com/image",
                Difficulty = DifficultyLevel.Advanced,
                Price = 100,
            };

            var instructorId = InstructorUser.Id.ToString();

            var courseId = await courseService.CreateCourseAndReturnIdAsync(courseFormViewModel, instructorId);

            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            Assert.IsNotNull(course);
        }

        [Test]
        public async Task AllAsyncShouldReturnAllCoursesAsync()
        {
            var queryModel = new AllCoursesQueryModel
            {
                CurrentPage = 1,
                CoursesPerPage = 9,
                SearchTerm = null,
            };

            var courses = await courseService.AllAsync(queryModel);

            var coursesInDb = context.Courses.Count();

            Assert.AreEqual(coursesInDb, courses.Courses.Count());
        }

        [Test]
        public async Task AllAsyncShouldNotReturnAllCoursesAsync()
        {
            var queryModel = new AllCoursesQueryModel
            {
                CurrentPage = 1,
                CoursesPerPage = 9,
                SearchTerm = null,
            };

            var courses = await courseService.AllAsync(queryModel);

            var coursesInDb = context.Courses.Count();

            Assert.AreNotEqual(coursesInDb + 1, courses.Courses.Count());
        }

        [Test]
        public async Task AllAsyncShouldReturnAllCoursesBySearchTermAsync()
        {
            var queryModel = new AllCoursesQueryModel
            {
                CurrentPage = 1,
                CoursesPerPage = 9,
                SearchTerm = "C#",
            };

            var courses = await courseService.AllAsync(queryModel);

            var coursesInDb = context.Courses.Count(c => c.Title.Contains(queryModel.SearchTerm));

            Assert.AreEqual(coursesInDb, courses.Courses.Count());
        }

        [Test]
        public async Task AllAsyncShouldNotReturnAllCoursesBySearchTermAsync()
        {
            var queryModel = new AllCoursesQueryModel
            {
                CurrentPage = 1,
                CoursesPerPage = 9,
                SearchTerm = "C#",
            };

            var courses = await courseService.AllAsync(queryModel);

            var coursesInDb = context.Courses.Count(c => c.Title.Contains(queryModel.SearchTerm));

            Assert.AreNotEqual(coursesInDb + 1, courses.Courses.Count());
        }

        [Test]
        public async Task AllByInstructorIdAsyncShouldReturnAllCoursesByInstructorId()
        {
            var instructorId = InstructorUser.Id.ToString();

            var courses = await courseService.AllByInstructorIdAsync(instructorId);

            var coursesInDb = context.Courses.Count(c => c.InstructorId.ToString() == instructorId);

            Assert.AreEqual(coursesInDb, courses.Count());
        }

        [Test]
        public async Task AllByInstructorIdAsyncShouldNotReturnAllCoursesByInstructorId()
        {
            var instructorId = InstructorUser.Id.ToString();

            var courses = await courseService.AllByInstructorIdAsync(instructorId);

            var coursesInDb = context.Courses.Count(c => c.InstructorId.ToString() == instructorId);

            Assert.AreNotEqual(coursesInDb + 1, courses.Count());
        }

        [Test]
        public async Task AllByUserIdAsyncShouldReturnAllCoursesByUserId()
        {
            var userId = StudentUser.Id.ToString();

            var courses = await courseService.AllByUserIdAsync(userId);

            var coursesInDb = context.Courses.Count(c => c.Instructor.UserId.ToString() == userId);

            Assert.AreEqual(coursesInDb, courses.Count());
        }

        [Test]
        public async Task AllByUserIdAsyncShouldNotReturnAllCoursesByUserId()
        {
            var userId = StudentUser.Id.ToString();

            var courses = await courseService.AllByUserIdAsync(userId);

            var coursesInDb = context.Courses.Count(c => c.Instructor.UserId.ToString() == userId);

            Assert.AreNotEqual(coursesInDb + 1, courses.Count());
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            var courseId = DatabaseSeeder.Course.Id.ToString();

            var result = await courseService.ExistsByIdAsync(courseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            var courseId = Guid.NewGuid().ToString();

            var result = await courseService.ExistsByIdAsync(courseId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DetailsAsyncShouldNotReturnCourseDetails()
        {
            var courseId = Course.Id.ToString();

            var courseDetails = await courseService.DetailsAsync(courseId);

            Assert.IsNull(courseDetails);
        }

        [Test]
        public async Task GetCourseForEditByIdAsyncShouldReturnCourseFormViewModel()
        {
            var courseId = Course.Id.ToString();

            var courseFormViewModel = await courseService.GetCourseForEditByIdAsync(courseId);

            Assert.IsNotNull(courseFormViewModel);
        }

        [Test]
        public async Task GetCourseForEditByIdAsyncShouldNotReturnCourseFormViewModel()
        {
            var courseId = Course.Id.ToString();

            var courseFormViewModel = await courseService.GetCourseForEditByIdAsync(courseId);

            Assert.IsNull(courseFormViewModel);
        }

        [Test]
        public async Task IsInstructorOfCourseAsyncShouldReturnTrueWhenIsInstructor()
        {
            var courseId = Course.Id.ToString();
            var instructorId = Instructor.Id.ToString();

            var result = await courseService.IsInstructorOfCourseAsync(courseId, instructorId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsInstructorOfCourseAsyncShouldReturnFalseWhenIsNotInstructor()
        {
            var courseId = Course.Id.ToString();
            var instructorId = Guid.NewGuid().ToString();

            var result = await courseService.IsInstructorOfCourseAsync(courseId, instructorId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task EditCourseByIdAsyncShouldEditCourse()
        {
            var courseFormViewModel = new CourseFormViewModel
            {
                Title = "Test Course",
                Description = "Test Description",
                CategoryId = 1,
                EndDate = "04/29/2024 12:22",
                ImagePath = "https://www.test.com/image",
                Difficulty = DifficultyLevel.Advanced,
                Price = 100,
            };

            var courseId = Course.Id.ToString();

            await courseService.EditCourseByIdAsync(courseFormViewModel, courseId);

            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            Assert.AreEqual(courseFormViewModel.Title, course.Title);
        }

        [Test]
        public async Task EditCourseByIdAsyncShouldNotEditCourse()
        {
            var courseFormViewModel = new CourseFormViewModel
            {
                Title = "Test Course1",
                Description = "Test Description",
                CategoryId = 1,
                EndDate = "04/29/2024 12:22",
                ImagePath = "https://www.test.com/image",
                Difficulty = DifficultyLevel.Advanced,
                Price = 100,
            };

            var courseId = Course.Id.ToString();

            await courseService.EditCourseByIdAsync(courseFormViewModel, courseId);

            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            Assert.AreNotEqual(courseFormViewModel.Title + "11", course.Title);
        }

        [Test]
        public async Task DeleteCourseByIdAsyncShouldDeleteCourse()
        {
            var courseId = Course.Id.ToString();

            await courseService.DeleteCourseByIdAsync(courseId);

            var course = await context.Courses.FirstOrDefaultAsync(c => c.Id.ToString() == courseId);

            Assert.IsNull(course);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncShouldCheckIfUserIsNotEnrolled()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncShouldCheckIfUserIsEnrolled()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncShouldCheckIfUserIsNotEnrolledAfterLeaving()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            await courseService.LeaveCourseAsync(courseId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncShouldCheckIfUserIsEnrolledAfterLeavingAndEnrollingAgain()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            await courseService.LeaveCourseAsync(courseId);

            await courseService.EnrollCourseAsync(courseId, userId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncShouldCheckIfUserIsEnrolledAfterLeavingAndEnrollingAgainAndLeavingAgain()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            await courseService.LeaveCourseAsync(courseId);

            await courseService.EnrollCourseAsync(courseId, userId);

            await courseService.LeaveCourseAsync(courseId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task EnrollCourseAsyncShouldEnrollCourse()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncCourseIdShouldReturnEnrolledCourse()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            var result = await courseService.IsEnrolledByIdAsync(courseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsEnrolledByIdAsyncCourseIdShouldNotReturnEnrolledCourse()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            var result = await courseService.IsEnrolledByIdAsync(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task LeaveCourseAsyncShouldLeaveCourse()
        {
            var courseId = Course.Id.ToString();
            var userId = StudentUser.Id.ToString();

            await courseService.EnrollCourseAsync(courseId, userId);

            await courseService.LeaveCourseAsync(courseId);

            var result = await courseService.IsEnrolledByIdAsync(courseId, userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetStatisticsAsyncShouldReturnStatistics()
        {
            var statistics = await courseService.GetStatisticsAsync();

            Assert.IsNotNull(statistics);
        }

        [Test]
        public async Task DeleteCoursesByCategoryIdAsyncShouldDeleteCourses()
        {
            var categoryId = 1;

            await courseService.DeleteCoursesByCategoryIdAsync(categoryId);

            var courses = await context.Courses.CountAsync(c => c.CategoryId == categoryId);

            Assert.AreEqual(0, courses);
        }

        [Test]
        public async Task DeleteCoursesByCategoryIdAsyncShouldNotDeleteCourses()
        {
            var categoryId = 1;

            await courseService.DeleteCoursesByCategoryIdAsync(categoryId);

            var courses = await context.Courses.CountAsync(c => c.CategoryId == categoryId);

            Assert.AreNotEqual(1, courses);
        }
    }
}