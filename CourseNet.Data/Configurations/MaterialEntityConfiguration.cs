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

            builder.HasOne(m => m.Lecture);

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
                    Description = "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP), включително инкапсулация, наследяване и полиморфизъм.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                    LectureId = 1,
                },
                new Material
                {
                    Id = 2,
                    Name = "Програмиране на C#",
                    Description = "Този материал представя теми по програмирането на C#, включително работа с LINQ, асинхронно програмиране и напреднали структури на данни.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                    LectureId = 2
                },

                new Material
                {
                Id = 3,
                Name = "Основи на базите данни",
                Description = "Този материал представя основни концепции и технологии в областта на базите данни, включително релационни бази данни, SQL заявки и моделиране на данни.",
                CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                LectureId = 3
                },

                new Material
                {
                Id = 4,
                Name = "Основи на бизнеса",
                Description = "Този материал представя основни концепции в областта на бизнеса, включително управление на проекти, маркетинг и стратегическо планиране.",
                CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                LectureId = 4
                },

                new Material
                {
                Id = 5,
                Name = "Дизайн принципи",
                Description = "Този материал представя основни принципи на дизайна, включително цветове, композиция и типография.",
                CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7"),
                LectureId = 5
                }
            };
        }
    }
}
