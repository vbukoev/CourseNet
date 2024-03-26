using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseNet.Web.ViewModels.Material
{
    public class MaterialSelectionFormViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int LectureId { get; set; } 
    }
}
