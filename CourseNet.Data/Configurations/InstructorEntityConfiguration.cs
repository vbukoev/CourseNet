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
           // builder.HasData(GenerateInstructors());
        }

        private Instructor[] GenerateInstructors()
        {
            ICollection<Instructor> instructors = new HashSet<Instructor>();
            var hasher = new PasswordHasher<Instructor>();
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                FirstName = "Instructor",
                LastName = "Instructorov",
                Email = "instructor@instructors.com",
                PhoneNumber = "+359123456789",
            };
            
            instructors.Add(instructor);

            return instructors.ToArray();
        }
    }
}
