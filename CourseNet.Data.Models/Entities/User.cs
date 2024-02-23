using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.User;
namespace CourseNet.Data.Models.Entities
{
    [Comment("User Table")]
    public class User
    {
        [Comment("User Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("User First Name")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Comment("User Last Name")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Comment("User Email Address")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Comment("User Email Address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;
        [Comment("User Email Address")]
        [Required]
        public string ProfileImageUrl { get; set; } 
        [Comment("Is The User Instructor boolean")]
        public bool IsInstructor { get; set; } 
        [Comment("Courses Taught collection")]
        public ICollection<Course> CoursesTaught { get; set; } = new List<Course>();

        [Comment("Enrollments collection")]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        [Comment("Reviews collection")]
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        [Comment("Certificates collection")]
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        [Comment("Payments collection")]
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
