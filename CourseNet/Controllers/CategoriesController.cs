using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using static CourseNet.Common.Notifications.NotificationMessagesConstants;

namespace CourseNet.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
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

            if(viewModel.GetUrlInformation() != information)
            {
                TempData[ErrorMessage] = "Не съществува такава категория";
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await this.categoriesService.GetCategoryForEditByIdAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDetailsViewModel model, int id)
        {
            await this.categoriesService.EditCategoryByIdAsync(model, id);

            return RedirectToAction("Index", "Categories");
        }
    }
}
