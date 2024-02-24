using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Course;
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
        public async Task<IEnumerable<CourseInfoViewModel>> GetAllCoursesAsync()
        {
            var courses = await context.Courses.Include(course => course.Instructor).ToListAsync();

            
            var coursesViewModel = courses.Select(course => new CourseInfoViewModel(id: course.Id, title: course.Title,
                description: course.Description, startDate: course.StartDate, endDate: course.EndDate,
                price: course.Price, instructorFirstName: course.Instructor?.FirstName,
                instructorLastName: course.Instructor?.LastName));

            return coursesViewModel;
        }
    }
}
