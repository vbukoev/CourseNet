using CourseNet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseNet.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Profile(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string userId, User editedUser)
        {

            if (!Equals(userId, editedUser.Id))
            {
                return NotFound();
            }

            User user = await _userManager.FindByIdAsync(userId);

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

