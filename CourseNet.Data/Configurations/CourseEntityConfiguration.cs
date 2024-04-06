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
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.CoursesTaught)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
