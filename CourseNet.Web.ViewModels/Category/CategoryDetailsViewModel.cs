using CourseNet.Web.ViewModels.Category.Interfaces;

namespace CourseNet.Web.ViewModels.Category
{
    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
