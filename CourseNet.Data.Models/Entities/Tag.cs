using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Tag;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Tag Table")]
    public class Tag
    {
        [Comment("Tag Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Tag Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Comment("Courses with the tag")]
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
    }
}
