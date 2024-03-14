using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategorySelectionFormViewModel>> GetAllCategoriesAsync();

        Task<bool> CategoryExists(int categoryId);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<AllCategoryViewModel>> AllCategoriesAsync();
        Task<string> CreateCategoryAndReturnIdAsync(CategoryDetailsViewModel model, string instructorId);

        Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int categoryId);

        Task<CategoryDetailsViewModel> GetCategoryForEditByIdAsync(int categoryId);

        Task EditCategoryByIdAsync(CategoryDetailsViewModel viewModel, int categoryId);
        Task<CategoryDetailsViewModel> GetCategoryForDeleteByIdAsync(int categoryId);

        Task DeleteCategoryByIdAsync(int categoryId);
    }
}
