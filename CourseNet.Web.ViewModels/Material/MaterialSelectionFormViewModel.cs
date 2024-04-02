using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
using static CourseNet.Common.DataConstants.Material;
namespace CourseNet.Web.ViewModels.Material
{
    /// <summary>
    /// Material Selection Form View Model
    /// </summary>
    public class MaterialSelectionFormViewModel
    {
        /// <summary>
        /// Name of the material
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the material
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Lecture Identifier
        /// </summary>
        public int LectureId { get; set; } 
    }
}
