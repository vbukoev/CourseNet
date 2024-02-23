using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseNet.Data.Models.Entities
{
    [Comment("CourseTag Table")]
    public class CourseTag
    {
        [Comment("Course Identifier")]
        [Required]
        public int CourseId { get; set; }
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        [Comment("Tag Identifier")]
        [Required]
        public int TagId { get; set; }
        [Comment("Tag")]
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } 
    }
}
