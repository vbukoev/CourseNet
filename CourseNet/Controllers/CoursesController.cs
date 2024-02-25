using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Course;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CourseFormViewModel();
            return this.View(viewModel);
        }
    }
}