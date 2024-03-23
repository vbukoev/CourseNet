using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static CourseNet.Common.DataConstants.Review;
namespace CourseNet.Data.Models.Entities
{
    [Comment("Review Table")]
    public class Review
    {
        [Comment("Review Identifier")]
        public int Id { get; set; }

        [Comment("Review Rating")]
        public int Rating { get; set; }

        [Comment("Review Comment")]
        [Required]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; } = string.Empty;

        [Comment("Review Date")]
        public DateTime Date { get; set; }
        
        [Comment("Course Identifier")]
        public Guid CourseId { get; set; }

        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}