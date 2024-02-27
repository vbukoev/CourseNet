using CourseNet.Data.Models.Entities;
using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Course;
using CourseNet.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

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
                InstructorId = Guid.Parse(instructorId),
                Price = model.Price,
            };

            await context.Courses.AddAsync(course);
        }
    }
}
