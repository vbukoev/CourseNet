using CourseNet.Services.Mapping;
namespace CourseNet.Web.ViewModels.Home
{
    public class IndexViewModel : IMapFrom<Data.Models.Entities.Course>
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!; 

        public string ImagePath { get; set; } = null!;
    }
}
