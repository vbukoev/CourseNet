using CourseNet.Web.ViewModels.Category.Interfaces;

namespace CourseNet.Web.Infrastructure.Extensions
{
    public static class ViewModelExtension
    {
        public static string GetUrlInformation(this ICategoryDetailsModel detailsModel)
        {
            return detailsModel.Name.Replace(" ", "-");
        }
    }
}
