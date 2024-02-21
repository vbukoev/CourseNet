namespace CourseNet.Models.Course
{
    public class CourseInfoViewModel
    {
        public CourseInfoViewModel(Data.Entities.Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
            Price = course.Price;
            InstructorFirstName = course.Instructor?.FirstName;
            InstructorLastName = course.Instructor?.LastName;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
    }
}
