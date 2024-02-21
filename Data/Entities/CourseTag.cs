using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Entities
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
