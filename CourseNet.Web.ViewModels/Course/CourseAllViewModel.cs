using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.Course;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
    /// <summary>
    /// Course All View Model which help creating the view for all courses
    /// </summary>
    public class CourseAllViewModel
    {
        /// <summary>
        /// Identifier of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Title of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;
        /// <summary>
        /// Image Path of the course image
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Път към снимка")]
        public string ImagePath { get; set; } = null!;
        /// <summary>
        /// Description of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Описание")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Price of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = LengthErrorMessage)]
        public decimal Price { get; set; }

        /// <summary>
        /// Boolean value if the course is enrolled
        /// </summary>
        [Display(Name = "Записан ли е курса")]
        public bool IsEnrolled { get; set; }

        /// <summary>
        /// Course Status if it is active or not
        /// </summary>

        public string Status { get; set; } = null!;
        /// <summary>
        /// Course End Date
        /// </summary>
        public string EndDate { get; set; } = null!;
        /// <summary>
        /// Course Difficulty
        /// </summary>
        public string Difficulty { get; set; } = null!;
    }
}
