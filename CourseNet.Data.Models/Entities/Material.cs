using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Material Table")]
    public class Material
    {
        public Material()
        {
            this.Id = System.Guid.NewGuid();
        }

        [Comment("Material Identifier")]
        public Guid Id { get; set; }

        [Comment("Material Name")]
        public string Name { get; set; }

        [Comment("Material Description")]
        public string Description { get; set; }

        [Comment("Material Path")]
        public Guid CourseId { get; set; }
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Comment("Instructor Identifier")]
        public Guid InstructorId { get; set; }

        [Comment("Instructor")]
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }
    }
}
