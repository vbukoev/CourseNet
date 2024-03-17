using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseNet.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasData(GenerateCategories());
        }

        public Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Programming"
            });

            categories.Add(new Category
            {
                Id = 2,
                Name = "Design"
            });

            categories.Add(new Category
            {
                Id = 3,
                Name = "Business"
            });

            return categories.ToArray();
        }
    }
}

