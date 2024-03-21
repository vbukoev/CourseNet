using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Models.Course;
using CourseNet.Services.Data.Models.Statistics;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<IndexViewModel>> GetAllCoursesAsync();

        Task<string> CreateCourseAndReturnIdAsync(CourseFormViewModel model, string instructorId);
        Task<AllCoursesFilteredAndPagedServiceModel> AllAsync(AllCoursesQueryModel queryModel);

        Task<IEnumerable<CourseAllViewModel>> AllByInstructorIdAsync(string instructorId);

        Task<IEnumerable<CourseAllViewModel>> AllByUserIdAsync(string userId);

        Task<bool> ExistsByIdAsync(string courseId);

        Task<CourseDetailsViewModel?> DetailsAsync(string courseId);

        Task<CourseFormViewModel> GetCourseForEditByIdAsync(string courseId);

        Task<bool> IsInstructorOfCourseAsync(string courseId, string instructorId);

        Task EditCourseByIdAsync(CourseFormViewModel model, string courseId);

        Task<CourseDeleteViewModel> GetCourseForDeleteByIdAsync(string courseId); 

        Task DeleteCourseByIdAsync(string courseId);

        Task<bool> IsEnrolledByIdAsync(string courseId);

        Task EnrollCourseAsync(string courseId, string userId);

        Task<bool> IsEnrolledByIdAsync(string courseId, string userId);

        Task LeaveCourseAsync(string courseId);

        Task<StatisticsServiceModel> GetStatisticsAsync();

        Task DeleteCoursesByCategoryIdAsync(int categoryId);
    }
}
