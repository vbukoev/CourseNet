namespace CourseNet.Models.Instructor
{
    public class InstructorViewModel
    {
        public InstructorViewModel(Data.Entities.Instructor instructor)
        {
            Id = instructor.Id;
            FirstName = instructor.FirstName;
            LastName = instructor.LastName;
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

    }
}
