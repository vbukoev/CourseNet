using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNet.Web.ViewModels.Course
{
    public class CourseCategorySelectFormModel
    {
        /// <summary>
        /// Category Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
