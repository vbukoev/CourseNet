using System.ComponentModel.DataAnnotations;
using CourseNet.Data.Models.Entities;

namespace CourseNet.Web.ViewModels.Review
{
    public class ReviewSelectionFormViewModel 
    {
        [Required(ErrorMessage = "Полето \"{0}\" е задължително.")]
        [Display(Name = "Оценка за курс")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Полето \"{0}\" е задължително.")]
        [Display(Name = "Коментар")]
        public string Comment { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string CourseId { get; set; }


    }
}
