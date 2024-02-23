using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Certificates Table")]
    public class Certificate
    {
        [Comment("Certificate Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("User Identifier")]
        [Required]
        public int UserId { get; set; } 
        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = new User();
        [Comment("Course Identifier")]
        [Required]
        public int CourseId { get; set; }
        [Comment("Course")]
        public Course Course { get; set; } = new Course();
        [Comment("Certificate Issue Date")]
        public DateTime IssueDate { get; set; }
        [Comment("Is Published boolean")]
        public bool IsPublished { get; set; }
    }
}
