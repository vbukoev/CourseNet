using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Data.Models.Entities.Enums;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Course;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly CourseNetDbContext context;
        private readonly ICourseService courseService;
        public CategoryService(CourseNetDbContext context, ICourseService courseService)
        {
            this.context = context;
            this.courseService = courseService;
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

        public async Task<string> CreateCategoryAndReturnIdAsync(CategoryDetailsViewModel model, string instructorId)
        {
            var category = new Category
            {
                Name = model.Name,
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category.Id.ToString();
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

        public async Task<CategoryDetailsViewModel> GetCategoryForEditByIdAsync(int id)
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            return new CategoryDetailsViewModel
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task EditCategoryByIdAsync(CategoryDetailsViewModel model, int categoryId)
        {
            var category = await context.Categories
                .FirstAsync(c => c.Id == categoryId);

            category.Name = model.Name;

            await context.SaveChangesAsync();
        }

        public async Task<CategoryDetailsViewModel> GetCategoryForDeleteByIdAsync(int categoryId)
        {
            var course = await context
                .Categories
                .FirstAsync(c => c.Id == categoryId);

            return new CategoryDetailsViewModel
            {
                Name = course.Name,
            };
        }

        public async Task DeleteCategoryByIdAsync(int categoryId)
        {
            var coursesWithCategory = await context.Courses.Where(c => c.CategoryId == categoryId).ToListAsync();

            if (coursesWithCategory.Any())
            {
                foreach (var course in coursesWithCategory)
                {
                    await courseService.DeleteCoursesByCategoryIdAsync(categoryId);
                }
            }

            var categoryToDelete = await context.Categories.FindAsync(categoryId);
            if (categoryToDelete != null)
            {
                context.Categories.Remove(categoryToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
