using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Course;

namespace CourseNet.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> Index()
        //{
        //    //IEnumerable<CourseInfoViewModel> viewModel = await courseService.GetAllCoursesAsync();

        //    //return View(viewModel);
        //}
    }
}