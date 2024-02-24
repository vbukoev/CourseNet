using System.Diagnostics;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;

        public HomeController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this.courseService.GetAllCoursesAsync();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
