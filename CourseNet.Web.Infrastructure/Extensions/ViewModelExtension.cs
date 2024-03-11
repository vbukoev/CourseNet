using CourseNet.Web.ViewModels.Category.Interfaces;

namespace CourseNet.Web.Infrastructure.Extensions
{
    public static class ViewModelExtension
    {
        public static string GetUrlInformation(ICategoryDetailsModel detailsModel)
        {
            return detailsModel.Name.Replace(" ", "-");
        }
    }
}
