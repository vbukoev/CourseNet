using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CourseNet.Data.Configurations
{
    public class InstructorEntityConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.HasData(GenerateInstructors());
        }

        public Instructor[] GenerateInstructors()
        {
            ICollection<Instructor> instructors = new HashSet<Instructor>();

            instructors.Add(new Instructor
            {
                Id = -1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@abv.bg"
            });

            instructors.Add(new Instructor
            {
                Id = -2,
                FirstName = "Kyle",
                LastName = "Doe",
                Email = "kyledoe@gmail.com"
            });

            instructors.Add(new Instructor
            {
                Id = -3,
                FirstName = "Harry",
                LastName = "Tailor",
                Email = "harrytailor@email.com"
            });

            return instructors.ToArray();
        }
    }
}
