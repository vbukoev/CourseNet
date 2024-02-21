namespace CourseNet.Models.Enrollment
{
    public class EnrollmentInfoViewModel
    {
        public EnrollmentInfoViewModel(Data.Entities.Enrollment enrollment)
        {
            Id = enrollment.Id;
            CourseId = enrollment.CourseId;
            UserId = enrollment.UserId;
        }
        /// <summary>
        /// Enrollment Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Enrollment Course Identifier
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Enrollment User Identifier
        /// </summary>
        public int UserId { get; set; }

    }
}
