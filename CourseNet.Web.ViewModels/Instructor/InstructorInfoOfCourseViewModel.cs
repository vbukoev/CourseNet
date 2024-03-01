using System.ComponentModel.DataAnnotations;

namespace CourseNet.Web.ViewModels.Instructor
{
    public class InstructorInfoOfCourseViewModel
    {
        public string Email { get; set; } = null!;
        [Display(Name="Телефон")]
        public string PhoneNumber { get; set; } = null!;
    }
}
