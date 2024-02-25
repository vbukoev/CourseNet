using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.Instructor;
namespace CourseNet.Web.ViewModels.Instructor
{
    public class BecomeInstructorFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber{ get; set; }
        public string Email { get; set; }
    }
}
