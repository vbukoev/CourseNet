using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data.Models.Entities
{
    [Comment("Question Table")]
    public class Question
    {
        [Comment("Question Identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Quiz Identifier")]
        [Required]
        public int QuizId { get; set; }
        [Comment("Quiz")]
        [ForeignKey(nameof(QuizId))]
        public Quiz Quiz { get; set; } = new Quiz();
        [Comment("Question Content")]
        [Required]
        public string Content { get; set; }

        [Comment("Answers Collection")] 
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
