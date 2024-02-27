using CourseNet.Web.ViewModels.Category;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategorySelectionFormViewModel>> GetAllCategoriesAsync();
        Task<bool> CategoryExists(int categoryId);
    }
}
