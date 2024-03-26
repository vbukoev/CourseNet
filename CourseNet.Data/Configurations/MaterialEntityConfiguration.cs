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

            builder.HasData(GenerateMaterials());
        }

        public Material[] GenerateMaterials()
        {
            return new[]
            {
                new Material
                {
                    Id = 1,
                    Name = "Принципи на Обектно-ориентираното програмиране",
                    Description = "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP)(https://bg.wikipedia.org/wiki/%D0%9E%D0%B1%D0%B5%D0%BA%D1%82%D0%BD%D0%BE_%D0%BE%D1%80%D0%B8%D0%B5%D0%BD%D1%82%D0%B8%D1%80%D0%B0%D0%BD%D0%BE_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%B8%D1%80%D0%B0%D0%BD%D0%B5), включително инкапсулация, наследяване и полиморфизъм.",
                    LectureId = 1,

                },
                new Material
                {
                    Id = 2,
                    Name = "Програмиране на C#",
                    Description = "Този материал представя теми по програмирането на C#(https://bg.wikipedia.org/wiki/C_Sharp),включително работа с LINQ, асинхронно програмиране(https://learn.microsoft.com/bg-bg/dotnet/csharp/asynchronous-programming/) и напреднали структури на данни.",
                    LectureId = 2,
                },

                new Material
                {
                Id = 3,
                Name = "Основи на базите данни",
                Description = "Този материал представя основни концепции и технологии в областта на базите данни(https://bg.wikipedia.org/wiki/%D0%91%D0%B0%D0%B7%D0%B0_%D0%B4%D0%B0%D0%BD%D0%BD%D0%B8), включително релационни бази данни, SQL заявки и моделиране на данни.",
                LectureId = 3,
                },

                new Material
                {
                Id = 4,
                Name = "Основи на бизнеса",
                Description = "Този материал представя основни концепции в областта на бизнеса(https://bg.wikipedia.org/wiki/%D0%91%D0%B8%D0%B7%D0%BD%D0%B5%D1%81),включително управление на проекти, маркетинг и стратегическо планиране.",
                LectureId = 4,
                },

                new Material
                {
                Id = 5,
                Name = "Дизайн принципи",
                Description = "Този материал представя основни принципи на дизайна(https://bg.wikipedia.org/wiki/%D0%94%D0%B8%D0%B7%D0%B0%D0%B9%D0%BD), включителноцветове, композиция и типография.",
                LectureId = 5,
                }
            };
        }
    }
}
