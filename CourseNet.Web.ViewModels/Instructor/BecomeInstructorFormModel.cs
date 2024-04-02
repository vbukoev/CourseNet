using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Instructor;
namespace CourseNet.Web.ViewModels.Instructor
{
    /// <summary>
    /// Instructor Become Form Model
    /// </summary>
    public class BecomeInstructorFormModel
    {
        /// <summary>
        /// Name of the instructor
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last Name of the instructor
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// PhoneNumber of the instructor
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber{ get; set; } = null!;
        /// <summary>
        /// Email of the instructor
        /// </summary>
        public string Email { get; set; } = null!;
    }
}
