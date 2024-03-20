using CourseNet.Data;
using CourseNet.Services.Data;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureSelectionFormViewModel viewModel, string courseId)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!await lecturesService.IsValidInstructor(viewModel.InstructorId))
                {
                    
                    ModelState.AddModelError(string.Empty, "Избраният инструктор не е валиден.");
                    return BadRequest(ModelState);
                }

                await lecturesService.CreateLectureAsync(viewModel, courseId);

                return Ok();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на лекцията!");
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
