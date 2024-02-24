using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Instructor;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Instructors Table")]
    public class Instructor
    {
        [Comment("Instructor Identifier")]
        [Key]
        public Guid Id { get; set; }
        [Comment("Instructor First Name")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Comment("Instructor Last Name")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Comment("Instructor Email Address")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Comment("Instructor Phone Number")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Comment("Courses taught by the instructor")]
        public ICollection<Course> CoursesTaught { get; set; } = new List<Course>();
    }
}
