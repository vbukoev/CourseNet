using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Category;
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

            Assert.AreEqual(context.Categories.Count(), categories.Count());
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
            int nonExistingCategoryId = 433;

            bool result = await categoryService.CategoryExists(nonExistingCategoryId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task CategoryExistsByNameAsyncShouldReturnTrueWhenExists()
        {
            string existingCategoryName = "Programming";

            bool result = await categoryService.CategoryExistsByNameAsync(existingCategoryName);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CategoryExistsByNameAsyncShouldReturnFalseWhenNotExists()
        {
            string nonExistingCategoryName = "Math(NotExisting)";

            bool result = await categoryService.CategoryExistsByNameAsync(nonExistingCategoryName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllCategoryNamesAsyncShouldReturnAllCategoryNames()
        {
            var allNames = await categoryService.AllCategoryNamesAsync();

            Assert.AreEqual(context.Categories.Count(), allNames.Count());
        }

        [Test]
        public async Task AllCategoryNamesAsyncShouldNotReturnAllCategoryNames()
        {
            var allNames = await categoryService.AllCategoryNamesAsync();

            Assert.AreNotEqual(context.Categories.Count() + 1, allNames.Count());
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategories()
        {
            var allCategories = await categoryService.AllCategoriesAsync();

            Assert.AreEqual(context.Categories.Count(), allCategories.Count());
        }

        [Test]
        public async Task AllCategoriesAsyncShouldNotReturnAllCategories()
        {
            var allCategories = await categoryService.AllCategoriesAsync();

            Assert.AreNotEqual(context.Categories.Count() + 1, allCategories.Count());
        }

        [Test]
        public async Task CreateCategoryAndReturnIdAsyncShouldCreateCategoryAndReturnId()
        {
            var model = new CategoryDetailsViewModel
            {
                Id = 1,
                Name = "NewCategory",
            };

            var categoryId = await categoryService.CreateCategoryAndReturnIdAsync(model);

            Assert.AreEqual(categoryId, categoryId);
        }

        [Test]
        public async Task CreateCategoryAndReturnIdAsyncShouldNotCreateCategoryAndReturnId()
        {
            var model = new CategoryDetailsViewModel
            {
                Id = 1,
                Name = "NewCategory",
            };

            var categoryId = await categoryService.CreateCategoryAndReturnIdAsync(model);

            Assert.AreNotEqual(categoryId + 1, categoryId);
        }

        [Test]
        public async Task GetCategoryDetailsAsyncShouldReturnCategoryDetails()
        {
            int categoryId = 1;

            var categoryDetails = await categoryService.GetCategoryDetailsAsync(categoryId);

            Assert.AreEqual(categoryId, categoryDetails.Id);
        }

        [Test]
        public async Task GetCategoryDetailsAsyncShouldNotReturnCategoryDetails()
        {
            int categoryId = 1;

            var categoryDetails = await categoryService.GetCategoryDetailsAsync(categoryId);

            Assert.AreNotEqual(2, categoryDetails.Id);
        }

        [Test]
        public async Task GetCategoryForEditByIdAsyncShouldReturnCategoryForEdit()
        {
            int categoryId = 1;

            var categoryForEdit = await categoryService.GetCategoryForEditByIdAsync(categoryId);

            Assert.AreEqual(categoryId, categoryForEdit.Id);
        }

        [Test]
        public async Task GetCategoryForEditByIdAsyncShouldNotReturnCategoryForEdit()
        {
            int categoryId = 1;

            var categoryForEdit = await categoryService.GetCategoryForEditByIdAsync(categoryId);

            Assert.AreNotEqual(2, categoryForEdit.Id);
        }

        [Test]
        public async Task EditCategoryByIdAsyncShouldEditCategory()
        {
            int categoryId = 1;
            var viewModel = new CategoryDetailsViewModel
            {
                Id = categoryId,
                Name = "EditedCategory",
            };

            await categoryService.EditCategoryByIdAsync(viewModel, categoryId);

            var category = await context.Categories.FindAsync(categoryId);

            Assert.AreEqual(viewModel.Name, category.Name);
        }

        [Test]
        public async Task EditCategoryByIdAsyncShouldNotEditCategory()
        {
            int categoryId = 1;
            var viewModel = new CategoryDetailsViewModel
            {
                Id = categoryId,
                Name = "EditedCategory",
            };

            await categoryService.EditCategoryByIdAsync(viewModel, categoryId);

            var category = await context.Categories.FindAsync(categoryId);

            Assert.AreNotEqual("NotEditedCategory", category.Name);
        }

        [Test]
        public async Task GetCategoryForDeleteByIdAsyncShouldReturnCategoryForDelete()
        {
            int categoryId = 1;

            var category = await context.Categories.FindAsync(categoryId);

            Assert.AreEqual(categoryId, category.Id);
        }

        [Test]
        public async Task GetCategoryForDeleteByIdAsyncShouldNotReturnCategoryForDelete()
        {
            int categoryId = 1;

            var category = await context.Categories.FindAsync(categoryId);

            Assert.AreNotEqual(2, category.Id);
        }


    }
}
