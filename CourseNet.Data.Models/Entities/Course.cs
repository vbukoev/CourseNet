using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseNet.Data.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Course;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Course Table")]
    public class Course
    {
        [Comment("Course Identifier")]
        [Key]
        public Guid Id { get; set; }
        [Comment("Course Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Comment("Course Description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Comment("Course Start Date")]
        [Required]
        public DateTime StartDate { get; set; }
        [Comment("Course End Date")]
        [Required]
        public DateTime EndDate { get; set; }
        [Comment("Course Price")]
        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("Course Instructor Identifier")]
        [Required]
        public Guid InstructorId { get; set; } 
        [Comment("Course Instructor")]
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; } = new Instructor();
        [Comment("Course Difficulty Level")]
        public DifficultyLevel Difficulty { get; set; }
        [Comment("Course Status")]
        public CourseStatus Status { get; set; }
        //[Comment("Course Enrollments")]
        //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
