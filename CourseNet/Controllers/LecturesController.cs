using CourseNet.Common.Notifications;
using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Instructor;
using CourseNet.Web.ViewModels.Lecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;
using static CourseNet.Common.ValidationErrors.General;
using CourseNet.Common.DataConstants;


namespace CourseNet.Web.Controllers
{
    public class LecturesController : Controller
    {
        private readonly CourseNetDbContext context;
        private readonly ILectureService lecturesService;
        private readonly IInstructorService instructorService;
        private readonly ICourseService coursesService;

        public LecturesController(CourseNetDbContext context, ILectureService lecturesService, IInstructorService instructorService, ICourseService coursesService)
        {
            this.context = context;
            this.lecturesService = lecturesService;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> AllLecturesForCourse(Guid courseId)
        {
            try
            {
                var viewModel = await lecturesService.GetAllLecturesForCourseAsync(courseId);
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете лекцията";

                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                LectureSelectionFormViewModel viewModel = new LectureSelectionFormViewModel();
                viewModel.CourseId = courseId.ToUpper();
                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureSelectionFormViewModel viewModel)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете лекцията";

                return RedirectToAction("Become", "Instructor");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                await lecturesService.AddLectureToCourseAsync(viewModel, viewModel.CourseId.ToUpper());
                TempData[SuccessMessage] = "Лекцията беше създадена успешно!";
                return RedirectToAction("AllLecturesForCourse", "Lectures", new { viewModel.CourseId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на лекцията!");
                return View(viewModel);
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = GeneralErrorMessage;
            return RedirectToAction("Index", "Home");
        }
    }

}