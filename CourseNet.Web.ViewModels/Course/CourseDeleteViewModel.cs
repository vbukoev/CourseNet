using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
