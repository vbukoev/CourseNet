using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Web.ViewModels.Instructor;

namespace CourseNet.Web.ViewModels.Course
{
    public class CourseDetailsViewModel : CourseAllViewModel
    {
        public string Category { get; set; } = null!;
        public InstructorInfoOfCourseViewModel Instructor { get; set; } = null!;
    }
}
