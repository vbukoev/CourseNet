using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Material;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;
using static CourseNet.Common.ValidationErrors.General;
namespace CourseNet.Web.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly CourseNetDbContext context;
        private readonly ILectureService lecturesService;
        private readonly IInstructorService instructorService;
        private readonly ICourseService coursesService;
        private readonly IMaterialService materialService;

        public MaterialsController(CourseNetDbContext context, ILectureService lecturesService, IInstructorService instructorService, ICourseService coursesService, IMaterialService materialService)
        {
            this.context = context;
            this.lecturesService = lecturesService;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
            this.materialService = materialService;
        }
        public async Task<IActionResult> AllMaterialsForLecture(int lectureId)
        {
            try
            {
                var viewModel = await materialService.GetAllMaterialsForLectureAsync(lectureId);
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(int lectureId)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете този материал към лекцията";

                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                MaterialSelectionFormViewModel viewModel = new MaterialSelectionFormViewModel();
                viewModel.LectureId = lectureId;
                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialSelectionFormViewModel viewModel)
        {
            bool isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да създадете този материал към лекцията";

                return RedirectToAction("Become", "Instructor");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                await materialService.AddMaterialToLectureAsync(viewModel, viewModel.LectureId);
                TempData[SuccessMessage] = "Материала към тази лекция беше създадена успешно!";
                return RedirectToAction("AllMaterialsForLecture", "Materials", new { viewModel.LectureId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на този материал към лекцията! Опитайте отново.");
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await materialService.GetMaterialForDeleteByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Материала не съществува!";
                return RedirectToAction("Index", "Courses");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] =
                    "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да изтриете материала";
                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                MaterialSelectionFormViewModel materialDeleteViewModel = await materialService.GetMaterialForDeleteByIdAsync(id);

                return View(materialDeleteViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MaterialSelectionFormViewModel viewModel, int id)
        {
            var model = await materialService.GetMaterialForDeleteByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Материала не съществува!";
                return RedirectToAction("Index", "Courses");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да изтриете материала";
                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                await materialService.DeleteMaterialByIdAsync(id);

                TempData[WarningMessage] = "Материала беше успешно изтрита!";

                return RedirectToAction("Index", "Courses");
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
