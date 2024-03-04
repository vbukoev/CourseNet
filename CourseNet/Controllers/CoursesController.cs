﻿using CourseNet.Services.Data.Interfaces;
using CourseNet.Services.Data.Models.Course;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Course;
using static CourseNet.Common.ValidationErrors.General;

using static CourseNet.Common.Notifications.NotificationMessagesConstants;

namespace CourseNet.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

            try
            {
                CourseFormViewModel model = new CourseFormViewModel
                {
                    Categories = await categoryService.GetAllCategoriesAsync()
                };

                return View(model);
            }
            catch (Exception e)
            {
                return GeneralError();
            }
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
                string courseId = await courseService.CreateCourseAndReturnIdAsync(model, instructorId);
                TempData[SuccessMessage] = "Курсът беше създаден успешно!";
                return RedirectToAction("Details", "Courses", new { id = courseId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на курса!");
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var model = await courseService.DetailsAsync(id);

            if (model == null)
            {
                return GeneralError();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await courseService.GetCourseForEditByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате курс";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
            bool isInstructorOwnerOfCourse = await courseService.IsInstructorOfCourseAsync(id, instructorId!);
            if (!isInstructorOwnerOfCourse)
            {
                TempData[ErrorMessage] = "Вие не сте собственик на този курс!";
                return RedirectToAction("Mine", "Courses");
            }
            try
            {
                CourseFormViewModel courseFormViewModel = await courseService.GetCourseForEditByIdAsync(id);

                courseFormViewModel.Categories = await categoryService.GetAllCategoriesAsync();
                TempData[WarningMessage] = "Влязохте в режим - Редакция на курс!";
                return View(courseFormViewModel);
            }
            catch (Exception e)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, CourseFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                formViewModel.Categories = await categoryService.GetAllCategoriesAsync();
                return View(formViewModel);
            }

            var model = await courseService.GetCourseForEditByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате курс";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
            bool isInstructorOwnerOfCourse = await courseService.IsInstructorOfCourseAsync(id, instructorId!);
            if (!isInstructorOwnerOfCourse)
            {
                TempData[ErrorMessage] = "Вие не сте собственик на този курс!";
                return RedirectToAction("Mine", "Courses");
            }
            try
            {
                await courseService.EditCourseByIdAsync(formViewModel, id);
                TempData[SuccessMessage] = "Курсът беше редактиран успешно!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при редактирането на курса!");
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);

            }
            return RedirectToAction("Details", "Courses", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await courseService.GetCourseForEditByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате курс";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
            bool isInstructorOwnerOfCourse = await courseService.IsInstructorOfCourseAsync(id, instructorId!);
            if (!isInstructorOwnerOfCourse)
            {
                TempData[ErrorMessage] = "Вие не сте собственик на този курс!";
                return RedirectToAction("Mine", "Courses");
            }

            try
            {
                CourseDeleteViewModel courseDeleteViewModel = await courseService.GetCourseForDeleteByIdAsync(id);

                return View(courseDeleteViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, CourseDeleteViewModel viewModel)
        {
            var model = await courseService.GetCourseForEditByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Курсът не съществува!";
                return RedirectToAction("Index", "Home");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате курс";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());
            bool isInstructorOwnerOfCourse = await courseService.IsInstructorOfCourseAsync(id, instructorId!);
            if (!isInstructorOwnerOfCourse)
            {
                TempData[ErrorMessage] = "Вие не сте собственик на този курс!";
                return RedirectToAction("Mine", "Courses");
            }

            try
            {
                await courseService.DeleteCourseByIdAsync(id);

                TempData[WarningMessage]= "Курсът беше изтрит успешно!";

                return RedirectToAction("Mine", "Courses"); 
            }
            catch (Exception)
            {
                return GeneralError();
                
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<CourseAllViewModel> courses = new List<CourseAllViewModel>();
            string userId = User.GetId();
            bool isInstructor = await instructorService.InstructorExistsByUserId(userId);
            try
            {
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
            catch (Exception)
            {

                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = GeneralErrorMessage;
            return RedirectToAction("Index", "Home");
        }
    }
}
