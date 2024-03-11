using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }
    }
}
