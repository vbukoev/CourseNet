using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Instructor;
namespace CourseNet.Web.ViewModels.Instructor
{
    /// <summary>
    /// Instructor Info Of Course View Model
    /// </summary>
    public class InstructorInfoOfCourseViewModel
    {
        /// <summary>
        /// Email of the instructor
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// Phone Number of the instructor
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name="Телефон")]
        public string PhoneNumber { get; set; } = null!;
    }
}
