using CourseNet.Data.Configurations;
using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CourseNet.Data.Migrations;

// ReSharper disable VirtualMemberCallInConstructor

namespace CourseNet.Data
{
    public class CourseNetDbContext : IdentityDbContext<CourseUser, IdentityRole<Guid>, Guid>
    {

        private readonly bool seedDb;
        public CourseNetDbContext(DbContextOptions<CourseNetDbContext> context, bool seedDb = true)
            : base(context)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEntityConfiguration());

            if (seedDb)
            {
                modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedCoursesEntityConfiguration());
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
