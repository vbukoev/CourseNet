using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.Lecture;

namespace CourseNet.Web.ViewModels.Lecture
{
    public class LectureSelectionFormViewModel
    {
        //[Required]
        //public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Име на лекцията")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        //[Required]
        //[Display(Name = "Дата")]
        //public DateTime Date { get; set; } 
        
        public string? CourseId { get; set; }

        public IEnumerable<LectureSelectionFormViewModel> Lectures { get; set; } = new HashSet<LectureSelectionFormViewModel>();
    }
}