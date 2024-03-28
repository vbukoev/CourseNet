using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<CourseUser> signInManager;
        private readonly UserManager<CourseUser> userManager;
        private readonly IUserStore<CourseUser> userStore;

        public UserController(
            UserManager<CourseUser> userManager,
            IUserStore<CourseUser> userStore,
            SignInManager<CourseUser> signInManager)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            CourseUser user = new CourseUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);
            //memoryCache.Remove(UsersCacheKey);

            return RedirectToAction("Index", "Home");
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
