using CourseNet.Web.ViewModels.Course.Enums;
using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
    public class AllCoursesQueryModel
    {
        public AllCoursesQueryModel()
        {
            CurrentPage = DefaultPage;
            CoursesPerPage = EntitiesPerPage;
        }
        public string? Category { get; set; }
        [Display(Name = "Търсене на курс")]
        public string? SearchTerm { get; set; }
        [Display(Name = "Сортиране на курсовете")]
        public CourseSorting CourseSorting { get; set; }
        public int CurrentPage { get; set; }
        public int CoursesPerPage { get; set; }
        public int TotalCourses { get; set; }
        public IEnumerable<string> Categories { get; set; } = new HashSet<string>();
        public IEnumerable<CourseAllViewModel> Courses { get; set; } = new HashSet<CourseAllViewModel>();
    }
}
