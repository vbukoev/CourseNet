using System.Text;
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
            var existingLectureId = 1;

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreEqual(context.Materials.Count(), materials.Count());
        }

        [Test]
        public async Task GetAllMaterialsForLectureAsyncShouldNotReturnAllMaterials()
        {
            var existingLectureId = 1;

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreNotEqual(materials.Count() + 1, materials.Count());
        }

        [Test]
        public async Task AddMaterialToLectureAsyncShouldAddMaterial()
        {
            var existingLectureId = 1;
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
        public async Task AddMaterialToLectureAsyncShouldNotAddMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreNotEqual(materials.Count() + 1, materials.Count());
        }

        [Test]
        public async Task GetMaterialForDeleteByIdAsyncShouldReturnMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToDelete = materials.First();

            var materialForDelete = await materialService.GetMaterialForDeleteByIdAsync(materialToDelete.Id);

            Assert.AreEqual(materialToDelete.Name, materialForDelete.Name);
        }

        [Test]
        public async Task GetMaterialForDeleteByIdAsyncShouldNotReturnMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToDelete = materials.First();

            var materialForDelete = await materialService.GetMaterialForDeleteByIdAsync(materialToDelete.Id);

            Assert.AreNotEqual(materialToDelete.Name + "1", materialForDelete.Name);
        }

        [Test]
        public async Task UpdateMaterialAsyncShouldUpdateMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToUpdate = materials.First();

            materialModel.Name = "Updated Title";
            materialModel.Description = "Updated Description";

            await materialService.UpdateMaterialAsync(materialModel, materialToUpdate.Id);

            var updatedMaterial = await materialService.GetMaterialForDeleteByIdAsync(materialToUpdate.Id);

            Assert.AreEqual(materialModel.Name, updatedMaterial.Name);
            Assert.AreEqual(materialModel.Description, updatedMaterial.Description);
        }

        [Test]
        public async Task DeleteMaterialByIdAsyncShouldDeleteMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToDelete = materials.First();

            await materialService.DeleteMaterialByIdAsync(materialToDelete.Id);

            var materialsAfterDelete = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreEqual(materials.Count() - 1, materialsAfterDelete.Count());
        }

        [Test]
        public async Task DeleteMaterialByIdAsyncShouldNotDeleteMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToDelete = materials.First();

            await materialService.DeleteMaterialByIdAsync(materialToDelete.Id);

            var materialsAfterDelete = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            Assert.AreNotEqual(materials.Count(), materialsAfterDelete.Count());
        }

        [Test]
        public async Task GetMaterialForUpdateAsyncShouldReturnMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToUpdate = materials.First();

            var materialForUpdate = await materialService.GetMaterialForUpdateAsync(materialToUpdate.Id);

            Assert.AreEqual(materialToUpdate.Name, materialForUpdate.Name);
        }

        [Test]
        public async Task GetMaterialForUpdateAsyncShouldNotReturnMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };
            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);

            var materialToUpdate = materials.First();

            var materialForUpdate = await materialService.GetMaterialForUpdateAsync(materialToUpdate.Id);

            Assert.AreNotEqual(materialToUpdate.Name + "1", materialForUpdate.Name);
        }

        [Test]
        public async Task UpdateMaterialAsyncShouldNotUpdateMaterial()
        {
            var existingLectureId = 1;
            var materialModel = new MaterialSelectionFormViewModel
            {
                LectureId = existingLectureId,
                Name = "Test Title",
                Description = "Test Description",
            };

            await materialService.AddMaterialToLectureAsync(materialModel);

            var materials = await materialService.GetAllMaterialsForLectureAsync(existingLectureId);
            var materialToUpdate = materials.First();

            materialModel.Name = "Updated Title";
            materialModel.Description = "Updated Description";

            await materialService.UpdateMaterialAsync(materialModel, materialToUpdate.Id);

            var updatedMaterial = await materialService.GetMaterialForDeleteByIdAsync(materialToUpdate.Id);

            Assert.AreNotEqual(materialModel.Name + "1", updatedMaterial.Name);
            Assert.AreNotEqual(materialModel.Description + "1", updatedMaterial.Description);
        }
    }
}
