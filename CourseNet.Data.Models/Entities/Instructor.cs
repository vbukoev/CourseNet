    using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseNet.Common.DataConstants.Instructor;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Instructors Table")]
    public class Instructor
    {
        public Instructor()     
        {
            this.Id = System.Guid.NewGuid();
        }

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
        public string Email { get; set; } = null!;

        [Comment("Instructor Phone Number")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        [Comment("User Identifier")]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual CourseUser User { get; set; } = null!;

        public virtual ICollection<Course> CoursesTaught { get; set; } = new HashSet<Course>();
    }
}
