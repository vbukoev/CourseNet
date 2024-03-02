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
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Display(Name = "Път към снимката")] public string ImagePath { get; set; } = null!;
    }
}
