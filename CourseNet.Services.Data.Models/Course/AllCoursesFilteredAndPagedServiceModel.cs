using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Services.Data.Models.Course
{
    public class AllCoursesFilteredAndPagedServiceModel
    {
        public int TotalCourses { get; set; }
        public IEnumerable<CourseAllViewModel> Courses { get; set; } = new HashSet<CourseAllViewModel>();  
    }
}
