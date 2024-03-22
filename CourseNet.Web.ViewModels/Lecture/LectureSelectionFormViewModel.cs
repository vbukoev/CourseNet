using System.ComponentModel.DataAnnotations;

public class LectureSelectionFormViewModel
{
    [Required(ErrorMessage = "Полето \"{0}\" е задължително.")]
    [Display(Name = "Заглавие")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Полето \"{0}\" е задължително.")]
    [Display(Name = "Описание")]
    public string Description { get; set; }

    [Display(Name = "Дата")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public Guid CourseId { get; set; }

}