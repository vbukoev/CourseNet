using System.ComponentModel.DataAnnotations;
namespace CourseNet.Web.ViewModels.Course
{
    /// <summary>
    /// Course Delete View Model which help creating the delete view
    /// </summary>
    public class CourseDeleteViewModel
    {
        /// <summary>
        /// Course Identifier
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Course Description
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Course Image Path
        /// </summary>
        [Display(Name = "Път към снимката")] 
        public string ImagePath { get; set; } = null!;
    }
}
