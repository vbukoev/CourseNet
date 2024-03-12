using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.User;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Student Table")]
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = System.Guid.NewGuid();
        }

        [Comment("Student Identifier")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Student First Name")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Student Last Name")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Comment("Student Email")]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Comment("Student Phone Number")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string Phone { get; set; } = string.Empty;
        
        public IEnumerable<Course> EnrolledCourses { get; set; } = new List<Course>();
    }
}
