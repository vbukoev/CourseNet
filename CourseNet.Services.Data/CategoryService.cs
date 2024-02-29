using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly CourseNetDbContext dbContext;
        public CategoryService(CourseNetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategorySelectionFormViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategorySelectionFormViewModel> categories = await this.dbContext.Categories
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
            bool res = await dbContext.Categories.AnyAsync(c => c.Id == categoryId);

            return res;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            var allNames = await dbContext
                .Categories
                .Select(c => c.Name)
                .ToListAsync();

            return allNames;
        }
    }
}
