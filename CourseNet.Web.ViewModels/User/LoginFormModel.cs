using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNet.Web.ViewModels.User
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        
        [Display(Name = "Запомни ме")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
