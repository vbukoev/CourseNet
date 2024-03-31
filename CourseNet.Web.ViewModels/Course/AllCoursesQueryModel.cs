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
        /// <summary>
        /// Тhe category of the course
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// The search term for the course
        /// </summary>
        [Display(Name = "Търсене на курс")]
        public string? SearchTerm { get; set; }

        /// <summary>
        /// The sorting of the courses
        /// </summary>
        [Display(Name = "Сортиране на курсовете")]
        public CourseSorting CourseSorting { get; set; }

        /// <summary>
        /// The current page of the courses
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Total courses per a page
        /// </summary>
        public int CoursesPerPage { get; set; }
        /// <summary>
        /// The total count of the courses
        /// </summary>
        public int TotalCourses { get; set; }

        /// <summary>
        /// Collection of all categories
        /// </summary>
        public IEnumerable<string> Categories { get; set; } = new HashSet<string>();

        /// <summary>
        /// Collection of all courses
        /// </summary>
        public IEnumerable<CourseAllViewModel> Courses { get; set; } = new HashSet<CourseAllViewModel>();
    }
}
