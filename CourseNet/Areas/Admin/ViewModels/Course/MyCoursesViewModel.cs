using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Web.Areas.Admin.ViewModels.Course
{
    public class MyCoursesViewModel
    {
        public IEnumerable<CourseAllViewModel> AddedCourses { get; set; } = null!;

        public IEnumerable<CourseAllViewModel> EnrolledCourses { get; set; } = null!;
    }
}
