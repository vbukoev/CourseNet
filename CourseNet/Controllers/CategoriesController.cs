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
            var categories = await this.categoriesService.AllCategoryNamesAsync();
            var viewModel = new CategorySelectionFormViewModel
            {
             
            };

            return View(viewModel);
        }
    }
}
