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
        public Course()
        {
            this.Id = System.Guid.NewGuid();
        }

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

        [Comment("Course Image Path")]
        public string ImagePath { get; set; } = string.Empty;

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
        public Instructor Instructor { get; set; } 
        [Comment("Course Difficulty Level")]
        public DifficultyLevel Difficulty { get; set; }
        [Comment("Course Status")]
        public CourseStatus Status { get; set; }
        
        public Guid? StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual ApplicationUser? Student { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
