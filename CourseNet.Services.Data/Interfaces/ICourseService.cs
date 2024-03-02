using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Services.Data.Models.Course;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Home;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<IndexViewModel>> GetAllCoursesAsync();
        Task CreateCourseAsync(CourseFormViewModel model, string instructorId);
        Task<AllCoursesFilteredAndPagedServiceModel> AllAsync(AllCoursesQueryModel queryModel);
        Task<IEnumerable<CourseAllViewModel>> AllByInstructorIdAsync(string instructorId);
        Task<IEnumerable<CourseAllViewModel>> AllByUserIdAsync(string userId);
        Task<CourseDetailsViewModel?> DetailsAsync(string courseId);
        Task<CourseFormViewModel> GetCourseForEditByIdAsync(string courseId);
        Task<bool> IsInstructorOfCourseAsync(string courseId, string instructorId);
        Task EditCourseByIdAsync(CourseFormViewModel model, string courseId);
    }
}
