using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Web.ViewModels.Category.Interfaces;

namespace CourseNet.Web.ViewModels.Category
{
    public class CategoryDetailsViewModel : ICategoryDetailsModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; }
    }
}
