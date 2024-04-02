using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseNet.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<CourseUser>
    {
        public void Configure(EntityTypeBuilder<CourseUser> builder)
        {
            //builder.Property(u => u.FirstName)
            //    .HasDefaultValue("Test");

            //builder.Property(u => u.LastName)
            //    .HasDefaultValue("Testov");

            builder.HasData(GenerateUsers());
        }

        public CourseUser[] GenerateUsers()
        {
            ICollection<CourseUser> users = new HashSet<CourseUser>();
            var hasher = new PasswordHasher<CourseUser>();
           
            //var student = new CourseUser
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Student",
            //    LastName = "Studentov",
            //    UserName = "test@students.com",
            //    NormalizedUserName = "TEST@STUDENTS.COM",
            //    Email = "test@students.com",
            //    NormalizedEmail = "TEST@STUDENTS.COM",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //student.PasswordHash = hasher.HashPassword(student, "123456");
            //users.Add(student);

            var futureInstructor = new CourseUser()
            {
                Id = Guid.NewGuid(),
                FirstName = "Future",
                LastName = "Instructor",
                UserName = "futureInstructor@instructors.com",
                NormalizedUserName = "FUTUREINSTRUCTOR@INSTRUCTORS.COM",
                Email = "futureInstructor@instructors.com",
                NormalizedEmail = "FUTUREINSTRUCTOR@INSTRUCTORS.COM",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            futureInstructor.PasswordHash = hasher.HashPassword(futureInstructor, "123456");
            users.Add(futureInstructor);

            return users.ToArray();
        }
    }
}
