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
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@abv.bg",
                PhoneNumber = "0887665555"
            });

            instructors.Add(new Instructor
            {
                Id = Guid.NewGuid(),
                FirstName = "Kyle",
                LastName = "Doe",
                Email = "kyledoe@gmail.com",
                PhoneNumber = "0886667755"
            });

            instructors.Add(new Instructor
            {
                Id = Guid.NewGuid(),
                FirstName = "Harry",
                LastName = "Tailor",
                Email = "harrytailor@email.com",
                PhoneNumber = "0888774444"
            });

            return instructors.ToArray();
        }
    }
}
