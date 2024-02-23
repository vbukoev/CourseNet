using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Review;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Review Table")]
    public class Review
    {
        [Comment("Review Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Course Identifier")]
        [Required]
        public int CourseId { get; set; }
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = new Course();
        [Comment("User Identifier")]
        [Required]
        public int UserId { get; set; }
        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = new User();
        [Comment("Review Comment")]
        [Required]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; } = string.Empty;
        [Comment("Review Rating")]
        [Required]
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; } 
    }
}
