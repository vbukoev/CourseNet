namespace CourseNet.Web.ViewModels.Instructor
{
    public class InstructorViewModel
    {
        public InstructorViewModel(Data.Models.Entities.Instructor instructor)
        {
            Id = instructor.Id;
            FirstName = instructor.FirstName;
            LastName = instructor.LastName;
            Email = instructor.Email;
        }
        /// <summary>
        /// Instructor Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Instructor First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Instructor Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Instructor Email Address
        /// </summary>
        public string Email { get; set; }
    }
}
