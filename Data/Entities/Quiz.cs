using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Data.DataConstants.Quiz;

namespace CourseNet.Data.Entities
{
    [Comment("Quiz Table")]
    public class Quiz
    {
        [Comment("Quiz Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Course Identifier")]
        [Required]
        public int CourseId { get; set; } 
        [Comment("Course")]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = new Course();
        [Comment("Quiz Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Comment("Quiz Questions")]
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
