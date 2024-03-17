using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseNet.Common.DataConstants.Material;
namespace CourseNet.Data.Models.Entities
{
    [Comment("Material Table")]
    public class Material
    {
        [Comment("Material Identifier")]
        public int Id { get; set; }

        [Comment("Material Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Material Description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Course Identifier")]
        public Guid CourseId { get; set; }

        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Comment("Instructor Identifier")]
        public Guid InstructorId { get; set; }

        [Comment("Instructor")]
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }

        [Comment("Lecture Identifier")]
        public int LectureId { get; set; }

        [Comment("Lecture")]
        [ForeignKey(nameof(LectureId))]
        public Lecture Lecture { get; set; }
    }
}
