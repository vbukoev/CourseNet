using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<CourseUser> _signInManager;
        private readonly UserManager<CourseUser> _userManager;
        private readonly IUserStore<CourseUser> _userStore;

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }
    }
}
