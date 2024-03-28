using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.User;
namespace CourseNet.Web.ViewModels.User
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата {0} трябва да бъде поне {2} и не повече от {1} символа дълга.")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Потвърждението на паролата не отговаря с горе въведената парола.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [Display(Name = "Име")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;
    }
}
