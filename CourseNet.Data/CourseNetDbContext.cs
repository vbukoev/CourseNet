using System.Reflection;
using CourseNet.Data.Configurations;
using CourseNet.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseNet.Data
{
    public class CourseNetDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        private readonly DbContextOptions<CourseNetDbContext> _context;

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
 
        public CourseNetDbContext(DbContextOptions<CourseNetDbContext> context)
            : base(context)
        {
            _context = context;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly configAssembly =
                Assembly.GetAssembly(typeof(CourseNetDbContext)) ?? Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
