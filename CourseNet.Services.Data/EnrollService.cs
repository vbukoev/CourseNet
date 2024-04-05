using System.Diagnostics;
using System.Runtime.CompilerServices;
using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.ViewModels.Enroll;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class EnrollService : IEnrollService
    {
        private readonly CourseNetDbContext context;

        public EnrollService(CourseNetDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<EnrollViewModel>> GetAllAsync()
        {
            IEnumerable<EnrollViewModel> enrollments = await context
                .Courses
                .Include(c => c.Student)
                .Include(c => c.Instructor)
                .ThenInclude(i => i.User)
                .Where(c => c.StudentId.HasValue)
                .Select(c => new EnrollViewModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    InstructorFullName = c.Instructor.FirstName + " " + c.Instructor.LastName,
                    InstructorEmail = c.Instructor.Email,
                    StudentFullName = c.Student!.FirstName + " " + c.Student.LastName,
                    StudentEmail = c.Student.Email,
                })
                .ToListAsync();

            return enrollments;
        }
    }
}
