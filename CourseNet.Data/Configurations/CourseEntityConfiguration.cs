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
                .Property(c => c.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.CoursesTaught)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateCourses());
        }

        public Course[] GenerateCourses()
        {
            ICollection<Course> courses = new HashSet<Course>();

            courses.Add(new Course
            {
                Title = "C# Fundamentals",
                Description = "Научете основите на C# език за програмиране",
                CategoryId = 1,
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                StudentId = Guid.Parse("F2DEDB39-40B0-4042-CBE4-08DC3524BC5D"),
                Difficulty = DifficultyLevel.Beginner,
                Status = CourseStatus.Active
            });

            courses.Add(new Course
            {
                Title = "Design Advanced ",
                Description = "Научете напреднали техники на дизайна",
                CategoryId = 2,
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                Difficulty = DifficultyLevel.Advanced,
                Status = CourseStatus.Completed
            });

            courses.Add(new Course
            {
                Title = "Business Management",
                Description = "Научете как да управлявате бизнеса си",
                CategoryId = 3,
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                Difficulty = DifficultyLevel.Intermediate,
                Status = CourseStatus.Archived
            });

            return courses.ToArray();
        }
    }
}
