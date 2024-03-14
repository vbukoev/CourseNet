using CourseNet.Web.ViewModels.Category.Interfaces;
using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Web.ViewModels.Category
{
    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<CategorySelectionFormViewModel> Categories { get; set; } = new HashSet<CategorySelectionFormViewModel>();
    }
}
