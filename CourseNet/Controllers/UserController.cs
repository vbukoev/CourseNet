using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string userId, ApplicationUser editedUser)
        {

            if (!Equals(userId, editedUser.Id))
            {
                return NotFound();
            }

            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = editedUser.FirstName;
            user.LastName = editedUser.LastName;
            user.BirthDate = editedUser.BirthDate;
            user.Address = editedUser.Address;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Profile", new { userId = user.Id });
        }
    }
}

