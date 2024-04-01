using CourseNet.Web.ViewModels.Course.Enums;
using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
    /// <summary>
    /// All Courses Query Model which help to filter and sort the courses
    /// </summary>
    public class AllCoursesQueryModel
    {
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
        public int CurrentPage { get; set; } = DefaultPage;

        /// <summary>
        /// Total courses per a page
        /// </summary>
        public int CoursesPerPage { get; set; } = EntitiesPerPage;

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
