using System.ComponentModel.DataAnnotations;
using CourseNet.Web.ViewModels.Instructor;
using CourseNet.Web.ViewModels.Lecture;

namespace CourseNet.Web.ViewModels.Course
{
    public class CourseDetailsViewModel : CourseAllViewModel
    {
        /// <summary>
        /// Category of the course for details
        /// </summary>
        [Display(Name = "Категория")]
        public string Category { get; set; } = null!;

        /// <summary>
        /// Instructor of the course
        /// </summary>
        public InstructorInfoOfCourseViewModel Instructor { get; set; } = null!;

        /// <summary>
        /// Collection of all lectures for the course
        /// </summary>
        public IEnumerable<LecturesForCourseViewModel> Lectures { get; set; } =
            new List<LecturesForCourseViewModel>();
    }
}
