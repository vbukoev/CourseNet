using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Data.Models.Entities.Enums;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Services.Data.Models.Course;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Course.Enums;
using CourseNet.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using static CourseNet.Common.DataConstants.Course;

namespace CourseNet.Services.Data
{
    public class CourseService : ICourseService
    {
        private readonly CourseNetDbContext context;

        public CourseService(CourseNetDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<IndexViewModel>> GetAllCoursesAsync()
        {
            IEnumerable<IndexViewModel> courses = await this.context.Courses
                .Select(c => new IndexViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    ImagePath = c.ImagePath,
                })
                .ToListAsync();

            return courses;
        }

        public async Task CreateCourseAsync(CourseFormViewModel model, string instructorId)
        {
            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                ImagePath = model.ImagePath,
                CategoryId = model.CategoryId,
                Price = model.Price,
                InstructorId = Guid.Parse(instructorId),
                Status = CourseStatus.Active,
                Difficulty = model.Difficulty,
                EndDate = DateTime.Parse(model.EndDate),
            };

            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task<AllCoursesFilteredAndPagedServiceModel> AllAsync(AllCoursesQueryModel queryModel)
        {
            IQueryable<Course> courseQuery = context
                .Courses
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                courseQuery = courseQuery
                    .Where(c => c.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm.ToLower()}%";

                courseQuery = courseQuery
                    .Where(c => 
                        EF.Functions.Like(c.Title, wildCard) ||EF.Functions.Like(c.Description,wildCard));
            }

            courseQuery = queryModel.CourseSorting switch
            {
                CourseSorting.LeastExpensive => courseQuery.OrderBy(c => c.Price),
                CourseSorting.MostExpensive => courseQuery.OrderByDescending(c => c.Price),
                CourseSorting.Newest => courseQuery.OrderBy(c => c.CreatedOn),
                CourseSorting.Oldest => courseQuery.OrderByDescending(c => c.CreatedOn),
                _ => courseQuery.OrderBy(c => c.InstructorId != null)
                    .ThenByDescending(c=>c.CreatedOn)
            };

            IEnumerable<CourseAllViewModel> courses = await courseQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CoursesPerPage)
                .Take(queryModel.CoursesPerPage)
                .Select(c => new CourseAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    Price = c.Price,
                    Difficulty = c.Difficulty.ToString(),
                    Status = c.Status.ToString(),
                    EndDate = c.EndDate.ToString(),
                    IsEnrolled = c.StudentId.HasValue,
                })
                .ToListAsync();

        }
    }
}
