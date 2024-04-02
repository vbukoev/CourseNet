using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.User;

namespace CourseNet.Data.Models.Entities
{
    [Comment("User Table")]
    public class CourseUser : IdentityUser<Guid>
    {
        public CourseUser()
        {
            this.Id = System.Guid.NewGuid();
        }

        [Comment("First Name of the User")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Comment("Last Name of the User")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ICollection<Course> AppliedCourses { get; set; } = new HashSet<Course>();
    }
}
