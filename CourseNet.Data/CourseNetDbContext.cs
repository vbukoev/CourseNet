using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CourseNet.Data
{
    public class CourseNetDbContext : IdentityDbContext<CourseUser, IdentityRole<Guid>, Guid>
    {

        private readonly DbContextOptions<CourseNetDbContext> _context;
        public CourseNetDbContext(DbContextOptions<CourseNetDbContext> context)
            : base(context)
        {
            _context = context;
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<CourseUser> Students { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly configAssembly =
                Assembly.GetAssembly(typeof(CourseNetDbContext)) ?? Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
