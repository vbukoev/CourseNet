using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Review;
namespace CourseNet.Web.ViewModels.Review
{
    /// <summary>
    /// Review Selection Form View Model
    /// </summary>
    public class ReviewSelectionFormViewModel 
    {
        /// <summary>
        /// Review Rating of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(RatingMinValue, RatingMaxValue, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Оценка за курс")]
        public int Rating { get; set; }
        /// <summary>
        /// Review Comment for the course
        /// </summary>

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Коментар")]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Review Date of creation
        /// </summary>
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Course Identifier for the review
        /// </summary>
        public string CourseId { get; set; }
    }
}
