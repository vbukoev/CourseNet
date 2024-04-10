using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;

namespace CourseNet.Services.Tests
{
    public class CategoryServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private CategoryService categoryService;
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

            categoryService = new CategoryService(context, courseService);
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldReturnAllCategories()
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            Assert.AreEqual(3, categories.Count());
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldNotReturnAllCategories()
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            Assert.AreNotEqual(2, categories.Count());
        }

        [Test]
        public async Task CategoryExistsShouldReturnTrueWhenExists()
        {
            int existingCategoryId = 1;

            bool result = await categoryService.CategoryExists(existingCategoryId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CategoryExistsShouldReturnFalseWhenNotExists()
        {
            int nonExistingCategoryId = 4;

            bool result = await categoryService.CategoryExists(nonExistingCategoryId);

            Assert.IsFalse(result);
        }
    }
}
