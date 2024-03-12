using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Review Table")]
    public class Review
    {
        public Review()
        {
            this.Id = System.Guid.NewGuid();
        }
        [Comment("Review Identifier")]
        public Guid Id { get; set; }
        [Comment("Review Rating")]
        public int Rating { get; set; }
        [Comment("Review Comment")]
        public string Comment { get; set; }
        [Comment("Review Date")]
        public DateTime Date { get; set; }
        [Comment("Course Identifier")]

        public Guid CourseId { get; set; }
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
        [Comment("Student Identifier")]

        public Guid UserId { get; set; }
        [Comment("Student")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
