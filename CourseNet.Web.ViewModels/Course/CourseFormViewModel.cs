using CourseNet.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using CourseNet.Data.Models.Entities.Enums;
using static CourseNet.Common.DataConstants.Course;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
    /// <summary>
    /// Course Form View Model 
    /// </summary>
    public class CourseFormViewModel 
    {
        /// <summary>
        /// The title of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// The description of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Course Image Path
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Път към снимката")]
        public string ImagePath { get; set; } = null!;

        /// <summary>
        /// The End Date of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Крайна дата")]
        public string EndDate { get; set; } = null!;

        /// <summary>
        /// The Difficulty of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Трудност")]
        [Range(0, 2)]
        public DifficultyLevel Difficulty { get; set; }

        /// <summary>
        /// Price of the course
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        /// <summary>
        /// Category of the course Identifier
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Collection of all categories for the course
        /// </summary>
        public IEnumerable<CategorySelectionFormViewModel> Categories { get; set; } = new HashSet<CategorySelectionFormViewModel>();
        
    }
}
