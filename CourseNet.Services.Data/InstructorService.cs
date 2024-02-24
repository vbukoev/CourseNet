using CourseNet.Data;
using CourseNet.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Services.Data
{
    public class InstructorService : IInstructorService
    {
        private readonly CourseNetDbContext dbContext;

        public InstructorService(CourseNetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> InstructorExistsByUserId(string? id)
        {
            bool result = await dbContext.Instructors.AnyAsync(instructor => instructor.Id.ToString() == id);

            return result;
        }
    }
}
