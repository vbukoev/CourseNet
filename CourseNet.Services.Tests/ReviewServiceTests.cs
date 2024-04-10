using CourseNet.Common.DataConstants;
using CourseNet.Data;
using CourseNet.Services.Data;
using CourseNet.Web.ViewModels.Review;
using Microsoft.EntityFrameworkCore;
using static CourseNet.Services.Tests.DatabaseSeeder;

namespace CourseNet.Services.Tests
{
    public class ReviewServiceTests
    {
        private DbContextOptions<CourseNetDbContext> dbOptions;
        private CourseNetDbContext context;
        private ReviewService reviewService;
        private CourseService courseService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<CourseNetDbContext>()
                .UseInMemoryDatabase("CourseNetInMemory" + Guid.NewGuid().ToString())
                .Options;
            context = new CourseNetDbContext(dbOptions);

            context.Database.EnsureCreated();
            SeedDatabase(context);

            reviewService = new ReviewService(context, courseService);
        }

        [Test]
        public async Task GetAllReviewsForCourseAsyncShouldReturnAllReviews()
        {
            var existingCourseId = context.Courses.First().Id;

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreEqual(context.Reviews.Count(), reviews.Count());
        }

        [Test]
        public async Task GetAllReviewsForCourseAsyncShouldNotReturnAllReviews()
        {
            var existingCourseId = context.Courses.First().Id;

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreNotEqual(reviews.Count() + 1, reviews.Count());
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldAddReview()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreEqual(context.Reviews.Count(), reviews.Count());
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldNotAddReview()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreNotEqual(reviews.Count() + 1, reviews.Count());
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldAddReviewWithCorrectRating()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreEqual(reviewModel.Rating, reviews.First().Rating);
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldNotAddReviewWithIncorrectRating()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreNotEqual(reviewModel.Rating + 1, reviews.First().Rating);
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldAddReviewWithCorrectCourseId()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreEqual(reviewModel.CourseId, reviews.First().CourseId.ToString());
        }

        [Test]
        public async Task AddReviewToCourseAsyncShouldNotAddReviewWithIncorrectCourseId()
        {
            var existingCourseId = context.Courses.First().Id;
            var reviewModel = new ReviewSelectionFormViewModel
            {
                CourseId = existingCourseId.ToString(),
                Rating = 5
            };

            await reviewService.AddReviewToCourseAsync(reviewModel, existingCourseId.ToString());

            var reviews = await reviewService.GetAllReviewsForCourseAsync(existingCourseId);

            Assert.AreNotEqual(reviewModel.CourseId + 1, reviews.First().CourseId.ToString());
        }
    }
}
