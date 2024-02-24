namespace CourseNet.Web.ViewModels.Enrollment
{
    public class EnrollmentInfoViewModel
    {
        //public EnrollmentInfoViewModel(Data.Models.Entities.Enrollment enrollment)
        //{
        //    Id = enrollment.Id;
        //    CourseId = enrollment.CourseId;
        //    UserId = enrollment.UserId;
        //}




        /// <summary>
        /// Enrollment Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Enrollment Course Identifier
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Enrollment User Identifier
        /// </summary>
        public Guid UserId { get; set; }
    }
}
