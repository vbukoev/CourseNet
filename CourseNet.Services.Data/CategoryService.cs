using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Course;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly CourseNetDbContext context;
        public CategoryService(CourseNetDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategorySelectionFormViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategorySelectionFormViewModel> categories = await this.context.Categories
                .AsNoTracking()
                .Select(c => new CategorySelectionFormViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            bool res = await context.Categories.AnyAsync(c => c.Id == categoryId);

            return res;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            var allNames = await context
                .Categories
                .Select(c => c.Name)
                .ToListAsync();

            return allNames;
        }

        public async Task<IEnumerable<AllCategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<AllCategoryViewModel> allCategories = await context.Categories
                .AsNoTracking()
                .Select(c => new AllCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();

            return allCategories;
        }

        public async Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int categoryId)
        {
            var category = await context.Categories
                    .FirstAsync(c => c.Id == categoryId);

            var categoryDetails = new CategoryDetailsViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryDetails;
        }

        public async Task<CategoryDetailsViewModel> GetCategoryForEditByIdAsync(int categoryId)
        {
            var category = await context.Categories
                .FirstAsync(c => c.Id == categoryId);

            return new CategoryDetailsViewModel
            {
                Id = categoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task EditCategoryByIdAsync(CategoryDetailsViewModel model, int categoryId)
        {
            var category = await context.Categories
                .FirstAsync(c => c.Id == categoryId);

            category.Name = model.Name;
            category.Description = model.Description;

            await context.SaveChangesAsync();
        }
    }
}
