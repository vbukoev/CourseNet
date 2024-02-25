using System.ComponentModel.DataAnnotations;
using CourseNet.Web.ViewModels.Category;
using static CourseNet.Common.DataConstants.Course;
namespace CourseNet.Web.ViewModels.Course
{
    public class CourseFormViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Път към снимката")]
        public string ImagePath { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CategorySelectionFormViewModel> Categories { get; set; } = new HashSet<CategorySelectionFormViewModel>();
    }
}
