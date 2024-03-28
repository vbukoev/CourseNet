using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseNet.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<CourseUser>
    {
        public void Configure(EntityTypeBuilder<CourseUser> builder)
        {
            builder.Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder.Property(u => u.LastName)
                .HasDefaultValue("Testov");
        }
    }
}
