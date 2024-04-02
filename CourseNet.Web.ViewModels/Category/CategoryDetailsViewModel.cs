using CourseNet.Web.ViewModels.Category.Interfaces;
using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Category;
namespace CourseNet.Web.ViewModels.Category
{
    /// <summary>
    /// Details View Model for the category
    /// </summary>
    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        /// <summary>
        /// Identifier of the category
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the category
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of courses in the category
        /// </summary>
        public IEnumerable<CategorySelectionFormViewModel> Categories { get; set; } = new HashSet<CategorySelectionFormViewModel>();
    }
}
