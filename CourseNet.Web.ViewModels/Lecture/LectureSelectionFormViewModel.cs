using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using static CourseNet.Common.DataConstants.Lecture;
using CourseNet.Web.ViewModels.Category;

namespace CourseNet.Web.ViewModels.Lecture
{
    public class LectureSelectionFormViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Име на лекцията")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Дата")]
        public string Date { get; set; }

        [Required] 
        public string CourseId { get; set; } = null!;

        [Required]
        public string InstructorId { get; set; } = null!;

        public IEnumerable<LectureSelectionFormViewModel> Lectures { get; set; } = new HashSet<LectureSelectionFormViewModel>();
    }
}