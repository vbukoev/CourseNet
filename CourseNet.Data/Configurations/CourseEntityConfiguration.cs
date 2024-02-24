using CourseNet.Data.Models.Entities;
using CourseNet.Data.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CourseNet.Data.Configurations
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasData(GenerateCourses());
        }

        public Course[] GenerateCourses()
        {
            ICollection<Course> courses = new HashSet<Course>();

            courses.Add(new Course
            {
                Id = Guid.NewGuid(),
                Title = "C# Fundamentals",
                Description = "Научете фундаментите на C# език за програмиране.",
                StartDate = new DateTime(2023, 7, 1),
                EndDate = new DateTime(2023, 8, 31),
                Price = 100,
                InstructorId = new Guid("5c87b86e-4f6a-470e-b432-16b674712a5b"),
                Difficulty = DifficultyLevel.Beginner,
                Status = CourseStatus.Active
            });

            return courses.ToArray();
        }
    }
}
