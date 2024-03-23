using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Review;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class ReviewService : IReviewService
    {
        private readonly CourseNetDbContext context;
        private readonly ICourseService courseService;

        public ReviewService(CourseNetDbContext context, ICourseService courseService)
        {
            this.context = context;
            this.courseService = courseService;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsForCourseAsync(Guid courseId)
        {
            return await context.Reviews
                .Where(r => r.CourseId == courseId)
                .ToListAsync();
        }

        public async Task AddReviewToCourseAsync(ReviewSelectionFormViewModel model, string courseId)
        {
            var review = new Review
            {
                Comment = model.Comment,
                Rating = model.Rating,
                Date = model.Date,
                CourseId = Guid.Parse(courseId),
            };

            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }
    }
}
