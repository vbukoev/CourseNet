using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
