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
        public async Task<IActionResult> AllLecturesForCourse(string courseId)
        {
            var viewModel = await lecturesService.GetAllLecturesForCourseAsync(courseId);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());
            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Трябва да си инструктор, за да се опиташ да създадеш лекция към курс!";
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureSelectionFormViewModel model, string courseId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());
            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Трябва да си инструктор, за да създадеш лекция към курс!";
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await lecturesService.AddLectureToCourseAsync(model, courseId);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Неочаквана грешка! Моля свържете се с нас или опитайте отново по-късно.";
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Courses");
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = GeneralErrorMessage;
            return RedirectToAction("Index", "Home");
        }
    }

}