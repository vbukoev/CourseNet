using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.DataConstants.GeneralApplicationConstants;
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
            if (User.IsInRole(AdministratorRoleName))
            {
                RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            IEnumerable<IndexViewModel> viewModel = await courseService.GetAllCoursesAsync();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }
    }
}
