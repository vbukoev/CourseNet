using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
