using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Course;

using static CourseNet.Common.Notifications.NotificationMessagesConstants;

namespace CourseNet.Web.Controllers
{
    using CourseNet.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IInstructorService instructorService;
        private readonly ICourseService courseService;
        public CoursesController(ICategoryService categoryService, IInstructorService instructorService, ICourseService courseService)
        {
            this.categoryService = categoryService;
            this.instructorService = instructorService;
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
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете курс";

                return RedirectToAction("Become", "Instructor");
            }

            CourseFormViewModel model = new CourseFormViewModel
            {
                Categories = await categoryService.GetAllCategoriesAsync()
            };
               
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseFormViewModel model)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете курс";

                return RedirectToAction("Become", "Instructor");
            }

            bool categoryExists = await categoryService.CategoryExists(model.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Категорията не съществува!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesAsync();

                return View(model);
            }

            try
            {
                string instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
                await courseService.CreateCourseAsync(model, instructorId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на курса!");
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}