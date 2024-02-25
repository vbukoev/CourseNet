using System.ComponentModel.DataAnnotations;
using CourseNet.Web.ViewModels.Category;
using static CourseNet.Common.DataConstants.Course;
namespace CourseNet.Web.ViewModels.Course
{
    public class CourseFormViewModel
    {
        public CourseFormViewModel()
        {
            Categories = new HashSet<CategorySelectionFormViewModel>();
        }
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Път към снимката")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Начална дата")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "Крайна дата")]
        public string EndDate { get; set; }
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public IEnumerable<CategorySelectionFormViewModel> Categories { get; set; } = new HashSet<CategorySelectionFormViewModel>();
    }
}
