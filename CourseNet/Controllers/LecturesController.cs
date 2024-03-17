using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Lecture;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;
using static CourseNet.Common.ValidationErrors.General;


namespace CourseNet.Web.Controllers
{
    public class LecturesController : Controller
    {
        private readonly CourseNetDbContext context;
        private readonly ILectureService lecturesService;
        private readonly IInstructorService instructorService;

        public LecturesController(CourseNetDbContext context, ILectureService lecturesService, IInstructorService instructorService)
        {
            this.context = context;
            this.lecturesService = lecturesService;
            this.instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> AllLecturesForCourse(string courseId)
        {
            var viewModel = await lecturesService.GetAllLecturesForCourseAsync(courseId);

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (isInstructor)
            {
                TempData[ErrorMessage] = "Вие сте инструктор! Трябва първо да сте студент, за да видите всички лекции към курса";
                return RedirectToAction("Become", "Instructor");
            }

            return View(viewModel);
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = GeneralErrorMessage;
            return RedirectToAction("Index", "Home");
        }
    }

}
