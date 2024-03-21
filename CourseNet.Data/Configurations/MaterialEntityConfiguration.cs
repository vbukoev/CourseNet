using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseNet.Data.Configurations
{
    public class MaterialEntityConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder
                .HasOne(m => m.Lecture)    
                .WithMany(l => l.Materials)    
                .HasForeignKey(m => m.LectureId);

            //builder.HasData(GenerateMaterials());
        }

        public Material[] GenerateMaterials()
        {
            return new[]
            {
                new Material
                {
                    Id = 1,
                    Name = "Принципи на Обектно-ориентираното програмиране",
                    Description = "Този материал представя основните принципи на обектноориентираното програмиране (OOP), включително инкапсулация, наследяване и полиморфизъм.",
                    
                    
                },
                new Material
                {
                    Id = 2,
                    Name = "Програмиране на C#",
                    Description = "Този материал представя теми по програмирането на C#,включително работа с LINQ, асинхронно програмиране и напреднали структури на данни.",
                    
                },

                new Material
                {
                Id = 3,
                Name = "Основи на базите данни",
                Description = "Този материал представя основни концепции и технологии в областтана базите данни, включително релационни бази данни, SQL заявки и моделиране на данни.",
                },

                new Material
                {
                Id = 4,
                Name = "Основи на бизнеса",
                Description = "Този материал представя основни концепции в областта на бизнеса,включително управление на проекти, маркетинг и стратегическо планиране.",
                
                },

                new Material
                {
                Id = 5,
                Name = "Дизайн принципи",
                Description = "Този материал представя основни принципи на дизайна, включителноцветове, композиция и типография.",
                }
            };
        }
    }
}
