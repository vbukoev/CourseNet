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
           builder
                .HasOne(c => c.Instructor)
                .WithMany(i => i.CoursesTaught)
                .HasForeignKey(c => c.InstructorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public Course[] GenerateCourses()
        {
            ICollection<Course> courses = new HashSet<Course>();

            Course course;

            course = new Course
            {
                Title = "C# Fundamentals",
                Description = "Научете основите на C# езика за програмиране",
                StartDate = new DateTime(2021, 1, 1),
                EndDate = new DateTime(2021, 1, 31),
                Price = 100,
                InstructorId = 1,
                Difficulty = DifficultyLevel.Beginner,
                Status = CourseStatus.Active
            };

            courses.Add(course);

            course = new Course
            {
                Title = "C# Advanced",
                Description = "Научи C# език за програмиране",
                StartDate = new DateTime(2021, 2, 1),
                EndDate = new DateTime(2021, 2, 28),
                Price = 150,
                InstructorId = 1,
                Difficulty = DifficultyLevel.Intermediate,
                Status = CourseStatus.Active
            };

            courses.Add(course);

            course = new Course
            {
                Title = "ASP.NET Core",
                Description = "Научи основите на ASP.NET Core",
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2021, 3, 31),
                Price = 200,
                InstructorId = 1,
                Difficulty = DifficultyLevel.Beginner,
                Status = CourseStatus.Active
            };

            courses.Add(course);

            course = new Course
            {
                Title = "ASP.NET Core Advanced",
                Description = "Научи по-сложните неща на ASP.NET Core",
                StartDate = new DateTime(2021, 4, 1),
                EndDate = new DateTime(2021, 4, 30),
                Price = 250,
                InstructorId = 1,
                Difficulty = DifficultyLevel.Advanced,
                Status = CourseStatus.Inactive
            };

            courses.Add(course);

            return courses.ToArray();
        }
    }
}
