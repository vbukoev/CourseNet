using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.ViewModels.Review;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static CourseNet.Common.Notifications.NotificationMessagesConstants;
using static CourseNet.Common.ValidationErrors.General;

namespace CourseNet.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly CourseNetDbContext context;
        private readonly IReviewService reviewsService;
        private readonly IInstructorService instructorService;
        private readonly ICourseService coursesService;

        public ReviewsController(CourseNetDbContext context, IReviewService reviewsService, IInstructorService instructorService, ICourseService coursesService)
        {
            this.context = context;
            this.reviewsService = reviewsService;
            this.instructorService = instructorService;
            this.coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> AllReviewsForCourse(Guid courseId)
        {
            try
            {
                var viewModel = await reviewsService.GetAllReviewsForCourseAsync(courseId);
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            try
            {
                ReviewSelectionFormViewModel viewModel = new ReviewSelectionFormViewModel();
                viewModel.CourseId = courseId.ToUpper();
                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewSelectionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                await reviewsService.AddReviewToCourseAsync(viewModel, viewModel.CourseId.ToUpper());
                TempData[SuccessMessage] = "Ревюто беше създадено успешно!";
                return RedirectToAction("AllReviewsForCourse", "Reviews", new { viewModel.CourseId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Възникна грешка при създаването на ревюто!");
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
