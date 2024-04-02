namespace CourseNet.Web.ViewModels.Lecture
{
    /// <summary>
    /// Lecture for Course View Model
    /// </summary>
    public class LecturesForCourseViewModel : LectureSelectionFormViewModel
    {
        /// <summary>
        /// Date of the course 
        /// </summary>
        public string Date { get; set; } = null!;
    }
}
