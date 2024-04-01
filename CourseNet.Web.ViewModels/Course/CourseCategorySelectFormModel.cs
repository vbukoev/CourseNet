using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.Category;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
    /// <summary>
    /// Course Category Select Form Model which help selecting category for the course
    /// </summary>
    public class CourseCategorySelectFormModel
    {
        /// <summary>
        /// Category Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
