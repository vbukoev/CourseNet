using CourseNet.Services.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Category;
using CourseNet.Web.ViewModels.Course;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;
using static CourseNet.Common.ValidationErrors.General;

namespace CourseNet.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoriesService;
        private readonly IInstructorService instructorService;

        public CategoriesController(ICategoryService categoriesService, IInstructorService instructorService)
        {
            this.categoriesService = categoriesService;
            this.instructorService = instructorService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AllCategoryViewModel> viewModel = await this.categoriesService.AllCategoriesAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            var viewModel = await this.categoriesService.GetCategoryDetailsAsync(id);
            bool exists = await this.categoriesService.CategoryExists(id);

            if (!exists)
            {
                TempData[ErrorMessage] = "Не съществува такава категория";
            }

            if (viewModel.GetUrlInformation() != information)
            {
                TempData[ErrorMessage] = "Не съществува такава категория";
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool exists = await categoriesService.CategoryExists(id);

            if (!exists)
            {
                TempData[ErrorMessage] = "Не съществува такава категория";
            }

            try
            {
                CategoryDetailsViewModel categoryViewModel = await categoriesService.GetCategoryForEditByIdAsync(id);

                TempData[WarningMessage] = "Влязохте в режим - Редакция на категория!";
                return View(categoryViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDetailsViewModel viewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await categoriesService.GetAllCategoriesAsync();
                return View(viewModel);
            }

            var model = await categoriesService.GetCategoryForEditByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Категорията не съществува!";
                return RedirectToAction("Index", "Categories");
            }

            try
            {
                await categoriesService.EditCategoryByIdAsync(viewModel, id);
                TempData[SuccessMessage] = "Категорията беше редактирана успешно!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при редактирането на категорията!");
                viewModel.Categories = await categoriesService.GetAllCategoriesAsync();
                return View(viewModel);

            }

            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await categoriesService.GetCategoryForDeleteByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Категорията не съществува!";
                return RedirectToAction("Index", "Categories");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] =
                    "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да изтриете категория";
                return RedirectToAction("Become", "Instructor");
            }

            var instructorId = await instructorService.GetInstructorIdByUserId(User.GetId());

            try
            {
                CategoryDetailsViewModel categoryDeleteViewModel = await categoriesService.GetCategoryForDeleteByIdAsync(id);

                return View(categoryDeleteViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDetailsViewModel viewModel, int id)
        {
            var model = await categoriesService.GetCategoryForDeleteByIdAsync(id);

            if (model == null)
            {
                TempData[ErrorMessage] = "Категорията не съществува!";
                return RedirectToAction("Index", "Categories");
            }

            var isInstructor = await instructorService.InstructorExistsByUserId(User.GetId());

            if (!isInstructor)
            {
                TempData[ErrorMessage] = "Вие не сте инструктор! Трябва първо да станете инструктор, за да успеете да редактирате категория";
                return RedirectToAction("Become", "Instructor");
            }

            try
            {
                await categoriesService.DeleteCategoryByIdAsync(id);

                TempData[WarningMessage] = "Категорията беше успешно изтрита!";

                return RedirectToAction("Index", "Categories");
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
