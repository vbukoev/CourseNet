using CourseNet.Web.ViewModels.Category;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategorySelectionFormViewModel>> GetAllCategoriesAsync();

        Task<bool> CategoryExists(int categoryId);

        Task<bool> CategoryExistsByNameAsync(string categoryName);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<IEnumerable<AllCategoryViewModel>> AllCategoriesAsync();

        Task<string> CreateCategoryAndReturnIdAsync(CategoryDetailsViewModel model);

        Task<CategoryDetailsViewModel> GetCategoryDetailsAsync(int categoryId);

        Task<CategoryDetailsViewModel> GetCategoryForEditByIdAsync(int categoryId);

        Task EditCategoryByIdAsync(CategoryDetailsViewModel viewModel, int categoryId);

        Task<CategoryDetailsViewModel> GetCategoryForDeleteByIdAsync(int categoryId);

        Task DeleteCategoryByIdAsync(int categoryId);
    }
}
