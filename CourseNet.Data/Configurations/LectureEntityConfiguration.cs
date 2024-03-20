﻿using CourseNet.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CourseNet.Data.Configurations
{
    public class LectureEntityConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder
                .Property(l => l.Date)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(l => l.Course)
                .WithMany(c => c.Lectures)
                .HasForeignKey(l => l.CourseId);

            builder.HasData(GenerateLectures());
        }

        public Lecture[] GenerateLectures()
        {
            return new[]
            {
                new Lecture
                {
                    Id = 1,
                    Title = "OOP",
                    Description = "Лекцията за обектно-ориентирано програмиране (ООП) обяснява принципите на създаване на софтуерни обекти, които имат данни и функции, свързани с тях, взаимодействайки помежду си. Програмистите използват концепции като инкапсулация, наследяване и полиморфизъм, за да създадат по-структуриран, поддържаем и разширяем код.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7")
                },
                new Lecture
                {
                    Id = 2,
                    Title = "C# Advanced Lecture",
                    Description = "Лекцията за напреднало програмиране на C# обхваща по-сложни концепции и техники за разработка на софтуер. Тя се фокусира върху напреднали теми като асинхронно програмиране, многонишковост, LINQ заявки, динамично програмиране и други. Участването в такава лекция допринася за разширяване на уменията на програмистите и за разработването на по-ефективен и оптимизиран софтуер.",
                    CourseId = Guid.Parse("FDCA4A09-56D7-4298-8393-C1271B2D83E5"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7")
                },
                new Lecture
                {
                    Id = 3,
                    Title = "DB Lecture",
                    Description = "Лекцията за бази данни (DB) представя основните понятия и технологии, свързани със съхранение и управление на данни. Тя обхваща различни модели на бази данни като релационни, NoSQL и графови, както и техники за проектиране на бази данни, оптимизация на заявки и сигурност на данните. Участниците усвояват знания и умения, необходими за създаване, управление и използване на бази данни в различни софтуерни проекти.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7")
                },
                new Lecture
                {
                    Id = 4,
                    Title = "Business Lecture",
                    Description = "Лекцията по бизнес представя основни принципи на бизнеса, включително стратегическо планиране, мениджмънт, маркетинг, финанси и операции. Участниците разбират как да анализират пазара, да разработят бизнес стратегии, да управляват финансовите ресурси и да създадат успешни продукти или услуги. Лекцията помага на студентите и професионалистите да разберат основите на бизнеса и да приложат тези знания в практиката.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7")
                },
                new Lecture
                {
                    Id = 5,
                    Title = "Design Lecture",
                    Description = "Лекцията по дизайн представя ключови концепции и методи за създаване на визуално привлекателни и функционални продукти или интерфейси. Тя обхваща теми като цветови теории, композиция, типография, UX (потребителски опит) и UI (потребителски интерфейс) дизайн. Участниците усвояват практически умения и инструменти за проектиране, които им помагат да създадат усъвършенствани и интуитивни продукти за крайните потребители.",
                    CourseId = Guid.Parse("3CE6E9D9-287A-4AA4-8C61-58FABC462DCE"),
                    InstructorId = Guid.Parse("2E96BDCE-D188-4E4D-9F37-ADDFE53F8FA7")
                }
            };
        }
    }
}