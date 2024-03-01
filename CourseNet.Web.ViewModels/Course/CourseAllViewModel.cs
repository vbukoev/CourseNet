using System.ComponentModel.DataAnnotations;

namespace CourseNet.Web.ViewModels.Course
{
    public class CourseAllViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        [Display(Name = "Път към снимка")]
        public string ImagePath { get; set; } = null!;  
        public string Description { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Записан ли е курса")]
        public bool IsEnrolled { get; set; }

        public string Status { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public string Difficulty { get; set; } = null!;
    }
}
