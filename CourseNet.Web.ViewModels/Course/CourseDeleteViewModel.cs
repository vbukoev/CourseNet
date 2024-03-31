using System.ComponentModel.DataAnnotations;
using static CourseNet.Common.DataConstants.Course;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
namespace CourseNet.Web.ViewModels.Course
{
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
