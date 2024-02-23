using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Common.DataConstants.Answer;
namespace CourseNet.Data.Models.Entities
{
    [Comment("Answers Table")]
    public class Answer
    {
        [Comment("Answer Identifier")]
        [Required]
        public int Id { get; set; }
        [Comment("Question Identifier")]
        [Required]
        public int QuestionId { get; set; }
        [Comment("Question")]
        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; } = new Question();
        [Comment("Answer Content")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } =  string.Empty;
        [Comment("Is Correct Answer")]
        public bool IsCorrect { get; set; }
    }
}
