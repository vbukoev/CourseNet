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

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете лекция към курс";

                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                LectureSelectionFormViewModel viewModel = new LectureSelectionFormViewModel()
                {
                    Lectures = await lecturesService.GetAllLecturesForCourseAsync(courseId)
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureSelectionFormViewModel viewModel, string courseId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете лекция към курс";

                return RedirectToAction("Become", "Instructor");
            }

            bool lectureExists = await lecturesService.LectureExistsByCourseId(courseId);

            if (lectureExists)
            {
                TempData[ErrorMessage] = "Неуспешно добавяне на лекция към курс!";
            }

            if (!ModelState.IsValid)
            {
                viewModel.Lectures = await lecturesService.GetAllLecturesForCourseAsync(courseId);

                return View(viewModel);
            }

            try
            {
                string lectureId = await lecturesService.CreateLectureAndReturnIdAsync();
                TempData[SuccessMessage] = "Лекцията беше създадена успешно!";
                return RedirectToAction("AllLecturesForCourse", "Lectures", new { id = lectureId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на лекцията!");
                viewModel.Lectures = await lecturesService.GetAllLecturesForCourseAsync(courseId);
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
