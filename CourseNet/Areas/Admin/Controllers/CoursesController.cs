using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Areas.Admin.ViewModels.Course;
using CourseNet.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class CoursesController : BaseAdminController
    {
        private readonly ICourseService courseService;
        private readonly IInstructorService instructorService;

        public CoursesController(ICourseService courseService, IInstructorService instructorService)
        {
            this.courseService = courseService;
            this.instructorService = instructorService;
        }

        public async Task<IActionResult> Mine()
        {
            string instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());

            MyCoursesViewModel viewModel = new MyCoursesViewModel
            {
                AddedCourses = await courseService.AllByInstructorIdAsync(instructorId),
                EnrolledCourses = await courseService.AllByUserIdAsync(User.GetId()!)
            };

            return View(viewModel);
        }
    }
}
