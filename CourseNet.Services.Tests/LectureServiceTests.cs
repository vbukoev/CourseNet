using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Lecture;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;

namespace CourseNet.Services.Tests
{
    public class LectureServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private CourseService courseService;
        private LectureService lectureService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            lectureService = new LectureService(context, courseService);
        }

        [Test]
        public async Task GetAllLecturesForCourseAsyncShouldReturnAllLectures()
        {
            var existingCourseId = context.Courses.First().Id;

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);

            Assert.AreEqual(context.Lectures.Count(), lectures.Count());
        }

        [Test]
        public async Task GetAllLecturesForCourseAsyncShouldNotReturnAllLectures()
        {
            var existingCourseId = context.Courses.First().Id;

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);

            Assert.AreNotEqual(lectures.Count() + 1, lectures.Count());
        }

        [Test]
        public async Task AddLectureToCourseAsyncShouldAddLecture()
        {
            var existingCourseId = context.Courses.First().Id;
            var lectureModel = new LectureSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Title = "Test Title",
                Description = "Test Description",
                Date = DateTime.UtcNow
            };

            await lectureService.AddLectureToCourseAsync(lectureModel, existingCourseId.ToString());

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);

            Assert.AreEqual(lectures.Count(), context.Lectures.Count());
        }

        [Test]
        public async Task GetLectureForDeleteByIdAsyncShouldReturnLecture()
        {
            var existingCourseId = context.Courses.First().Id;
            var lectureModel = new LectureSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Title = "Test Title",
                Description = "Test Description",
                Date = DateTime.UtcNow
            };

            await lectureService.AddLectureToCourseAsync(lectureModel, existingCourseId.ToString());

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);
            var lectureToDelete = lectures.First();

            var lectureForDelete = await lectureService.GetLectureForDeleteByIdAsync(lectureToDelete.Id);

            Assert.AreEqual(lectureToDelete.Title, lectureForDelete.Title);
        }

        [Test]
        public async Task GetLectureForDeleteByIdAsyncShouldNotReturnLecture()
        {
            var existingCourseId = context.Courses.First().Id;
            var lectureModel = new LectureSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Title = "Test Title",
                Description = "Test Description",
                Date = DateTime.UtcNow
            };

            await lectureService.AddLectureToCourseAsync(lectureModel, existingCourseId.ToString());

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);
            var lectureToDelete = lectures.First();

            var lectureForDelete = await lectureService.GetLectureForDeleteByIdAsync(lectureToDelete.Id);

            Assert.AreNotEqual(lectureToDelete.Title + "1", lectureForDelete.Title);
        }

        [Test]
        public async Task DeleteLectureByIdAsyncShouldDeleteLecture()
        {
            var existingCourseId = context.Courses.First().Id;
            var lectureModel = new LectureSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Title = "Test Title",
                Description = "Test Description",
                Date = DateTime.UtcNow
            };

            await lectureService.AddLectureToCourseAsync(lectureModel, existingCourseId.ToString());

            var lectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);
            var lectureToDelete = lectures.First();

            await lectureService.DeleteLectureByIdAsync(lectureToDelete.Id);

            var updatedLectures = await lectureService.GetAllLecturesForCourseAsync(existingCourseId);

            Assert.AreEqual(updatedLectures.Count(), lectures.Count() - 1);
        }

        
    }
}
