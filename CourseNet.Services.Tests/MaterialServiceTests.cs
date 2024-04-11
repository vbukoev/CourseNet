using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Material;
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

        [Test]
        public async Task GetAllMaterialsForLectureAsyncShouldNotReturnAllMaterials()
        {
            var existingLectureId = context.Lectures.First().Id;

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreNotEqual(materials.Count() + 1, materials.Count());
        }

        [Test]
        public async Task AddMaterialToLectureAsyncShouldAddMaterial()
        {
            var existingLectureId = context.Lectures.First().Id;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreEqual(context.Materials.Count(), materials.Count());
        }

        [Test]
        public async Task DeleteMaterialByIdAsyncShouldDeleteMaterial()
        {
            var existingMaterialId = context.Materials.First().Id;

            await materialService.DeleteMaterialByIdAsync(existingMaterialId);

            var materials = await materialService.GetAllMaterialsForLectureAsync(context.Lectures.First().Id);

            Assert.AreNotEqual(existingMaterialId, materials.First().Id);
        }

        [Test]
        public async Task UpdateMaterialAsyncShouldUpdateMaterial()
        {
            var existingMaterialId = context.Materials.First().Id;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = context.Lectures.First().Id,
                Name = "Test Title",
                Description = "Test Description",
                
            };

            await materialService.UpdateMaterialAsync(materialModel, existingMaterialId);

            var material = await materialService.GetMaterialForUpdateAsync(existingMaterialId);

            Assert.AreEqual(materialModel.Name, material.Name);
        }
    }
}
