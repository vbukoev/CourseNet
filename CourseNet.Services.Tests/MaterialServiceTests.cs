using CourseNet.Data;
using CourseNet.Services.Data;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;

namespace CourseNet.Services.Tests
{
    public class MaterialServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private MaterialService materialService;
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

            materialService = new MaterialService(context, lectureService);
        }

        [Test]
        public async Task GetAllMaterialsForLectureAsyncShouldReturnAllMaterials()
        {
            var existingLectureId = context.Lectures.First().Id;

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreEqual(context.Materials.Count(), materials.Count());
        }
    }
}
