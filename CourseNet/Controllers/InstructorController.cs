using CourseNet.Common.Notifications;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Instructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;
namespace CourseNet.Web.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorService instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.GetId();
            bool isInstructor = await instructorService.InstructorExistsByUserId(userId);

            if (isInstructor)
            {
                TempData[ErrorMessage] = "Вече си инструктор!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeInstructorFormModel model)
        {
            string? userId = User.GetId();
            bool isInstructor = await instructorService.InstructorExistsByUserId(userId);

            if (isInstructor)
            {
                TempData[NotificationMessagesConstants.ErrorMessage] = "Вече си инструктор!";
                return RedirectToAction("Index", "Home");
            }
            bool isPhoneNumberTaken = await instructorService.InstructorExistsByPhoneNumber(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Този телефонен номер вече е зает!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool userHasAppliedCourses = await this.instructorService.HasAppliedCoursesByUserIdAsync(userId);

            if (userHasAppliedCourses)
            {
                TempData[ErrorMessage] = "Не можете да станете инструктор, докато имате курсове, в които участвате!";
                return RedirectToAction("Mine", "Courses");
            }

            try
            {
                await instructorService.Create(userId, model);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Неочаквана грешка! Моля свържете се с нас или опитайте отново по-късно.";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Courses");
        }
    }
}
