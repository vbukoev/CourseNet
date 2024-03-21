﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedLecturesInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "CourseId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Лекцията за обектно-ориентирано програмиране (ООП) обяснява принципите на създаване на софтуерни обекти, които имат данни и функции, свързани с тях, взаимодействайки помежду си. Програмистите използват концепции като инкапсулация, наследяване и полиморфизъм, за да създадат по-структуриран, поддържаем и разширяем код.", "OOP" },
                    { 2, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Лекцията за напреднало програмиране на C# обхваща по-сложни концепции и техники за разработка на софтуер. Тя се фокусира върху напреднали теми като асинхронно програмиране, многонишковост, LINQ заявки, динамично програмиране и други. Участването в такава лекция допринася за разширяване на уменията на програмистите и за разработването на по-ефективен и оптимизиран софтуер.", "C# Advanced Lecture" },
                    { 3, new Guid("fdca4a09-56d7-4298-8393-c1271b2d83e5"), "Лекцията за бази данни (DB) представя основните понятия и технологии, свързани със съхранение и управление на данни. Тя обхваща различни модели на бази данни като релационни, NoSQL и графови, както и техники за проектиране на бази данни, оптимизация на заявки и сигурност на данните. Участниците усвояват знания и умения, необходими за създаване, управление и използване на бази данни в различни софтуерни проекти.", "DB Lecture" },
                    { 4, new Guid("fdca4a09-56d7-4298-8393-c1271b2d83e5"), "Лекцията по бизнес представя основни принципи на бизнеса, включително стратегическо планиране, мениджмънт, маркетинг, финанси и операции. Участниците разбират как да анализират пазара, да разработят бизнес стратегии, да управляват финансовите ресурси и да създадат успешни продукти или услуги. Лекцията помага на студентите и професионалистите да разберат основите на бизнеса и да приложат тези знания в практиката.", "Business Lecture" },
                    { 5, new Guid("fdca4a09-56d7-4298-8393-c1271b2d83e5"), "Лекцията по дизайн представя ключови концепции и методи за създаване на визуално привлекателни и функционални продукти или интерфейси. Тя обхваща теми като цветови теории, композиция, типография, UX (потребителски опит) и UI (потребителски интерфейс) дизайн. Участниците усвояват практически умения и инструменти за проектиране, които им помагат да създадат усъвършенствани и интуитивни продукти за крайните потребители.", "Design Lecture" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
