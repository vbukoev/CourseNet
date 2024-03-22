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
        public async Task<IActionResult> AllLecturesForCourse(string courseId)
        {
            IEnumerable<LecturesForCourseViewModel> lectures = await lecturesService.GetAllLecturesForCourseAsync(courseId);

            var viewModel = lectures.Select(lecture => new LecturesForCourseViewModel
            {
                Title = lecture.Title,
                Description = lecture.Description,
                Date = lecture.Date,
                CourseId = lecture.CourseId 
            });

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете лекция";

                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                var viewModel = new LectureSelectionFormViewModel();
                viewModel.CourseId = courseId;
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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                string courseId = Request.Form["courseId"];

                await lecturesService.AddLectureToCourseAsync(viewModel, courseId);

                return RedirectToAction("AllLecturesForCourse", "Lectures", new { courseId = courseId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на лекцията: ");
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