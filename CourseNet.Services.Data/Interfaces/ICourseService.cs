using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseInfoViewModel>> GetAllCoursesAsync();
    }
}
