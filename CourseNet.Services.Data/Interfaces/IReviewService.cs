using CourseNet.Data.Models.Entities;
using CourseNet.Web.ViewModels.Review;

namespace CourseNet.Services.Data.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsForCourseAsync(Guid courseId);

        Task AddReviewToCourseAsync(ReviewSelectionFormViewModel model, string courseId);
    }
}
