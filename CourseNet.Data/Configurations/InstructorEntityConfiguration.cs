using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CourseNet.Data.Configurations
{
    public class InstructorEntityConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
           builder.HasData(GenerateInstructors());
        }

        private Instructor[] GenerateInstructors()
        {
            ICollection<Instructor> instructors = new HashSet<Instructor>();
            var hasher = new PasswordHasher<Instructor>();
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                FirstName = "Future",
                LastName = "Instructor",
                Email = "futureInstructor@instructors.com",
                PhoneNumber = "+359123456789",
                UserId = Guid.Parse("120206E2-D1E9-4B04-BF2C-943FE9A1793D")
            };
            
            instructors.Add(instructor);

            return instructors.ToArray();
        }
    }
}
