namespace CourseNet.Web.ViewModels.Lecture
{
    public class LectureCreateViewModel
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime Date { get; set; } 
        public static Data.Models.Entities.Course Course { get; set; }
        public IEnumerable<Data.Models.Entities.Course> Courses { get; set; } = new HashSet<Data.Models.Entities.Course>();
    }
}
