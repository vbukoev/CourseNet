using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Home;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<IndexViewModel>> GetAllCoursesAsync();
    }
}
