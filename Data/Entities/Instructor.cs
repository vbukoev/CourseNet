using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Data.DataConstants.Instructor;
namespace CourseNet.Data.Entities
{
    [Comment("Instructors Table")]
    public class Instructor
    {
        [Comment("Instructor Identifier")]
        [Key]
        public int Id { get; set; }
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
        [Comment("Courses taught by the instructor")]
        public ICollection<Course> CoursesTaught { get; set; } = new List<Course>();
    }
}
