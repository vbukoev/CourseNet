using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Enrollments Table")]
    public class Enrollment
    {
        [Comment("Enrollment Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("User Identifier")]
        [Required]
        public int UserId { get; set; }
        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [Comment("Course Identifier")]
        [Required]
        public int CourseId { get; set; }
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        [Comment("Enrollment Date")]
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Comment("Is Completed boolean")]
        public bool IsCompleted { get; set; } 
    }
}
