using CourseNet.Services.Data.Interfaces;
using CourseNet.Services.Data.Models.Course;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] AllCoursesQueryModel queryModel)
        {
            AllCoursesFilteredAndPagedServiceModel serviceModel = await courseService.AllAsync(queryModel);
            queryModel.Courses = serviceModel.Courses;
            queryModel.TotalCourses = serviceModel.TotalCourses;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            return View(queryModel);
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var model = await courseService.DetailsAsync(id);
           
            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await courseService.GetCourseForEditByIdAsync(id);
            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());
            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате курс";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
            bool isInstructorOwnerOfCourse = await courseService.IsInstructorOfCourseAsync(id, instructorId);
            if (!isInstructorOwnerOfCourse)
            {
                TempData[ErrorMessage] = "Вие не сте собственик на този курс!";
                return RedirectToAction("Mine", "Courses");
            }
            CourseFormViewModel courseFormViewModel = await courseService.GetCourseForEditByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<CourseAllViewModel> courses = new List<CourseAllViewModel>();
            string userId = User.GetId();
            bool isInstructor = await instructorService.InstructorExistsByUserId(userId);
            if (isInstructor)
            {
                string instructorId = await instructorService.GetInstructorIdByUserId(userId);
                courses.AddRange(await courseService.AllByInstructorIdAsync(instructorId!));
            }
            else
            {
                courses.AddRange(await courseService.AllByUserIdAsync(userId));
            }

            return View(courses);
        }
    }
}