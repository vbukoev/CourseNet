using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class RemovedUnusedPropFromEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Instructors_InstructorId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Lectures_LectureId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Materials_InstructorId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_LectureId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Lectures");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Course Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Course Identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Lectures",
                type: "datetime2",
                nullable: false,
                comment: "Lecture Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Lecture Date");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Course Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Course Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Course Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Instructor Identifier");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Lecture Identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Lectures",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Lecture Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Lecture Date");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Course Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Instructor Identifier");

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "CourseId", "Date", "Description", "InstructorId", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лекцията за обектно-ориентирано програмиране (ООП) обяснява принципите на създаване на софтуерни обекти, които имат данни и функции, свързани с тях, взаимодействайки помежду си. Програмистите използват концепции като инкапсулация, наследяване и полиморфизъм, за да създадат по-структуриран, поддържаем и разширяем код.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), "OOP" },
                    { 2, new Guid("fdca4a09-56d7-4298-8393-c1271b2d83e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лекцията за напреднало програмиране на C# обхваща по-сложни концепции и техники за разработка на софтуер. Тя се фокусира върху напреднали теми като асинхронно програмиране, многонишковост, LINQ заявки, динамично програмиране и други. Участването в такава лекция допринася за разширяване на уменията на програмистите и за разработването на по-ефективен и оптимизиран софтуер.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), "C# Advanced Lecture" },
                    { 3, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лекцията за бази данни (DB) представя основните понятия и технологии, свързани със съхранение и управление на данни. Тя обхваща различни модели на бази данни като релационни, NoSQL и графови, както и техники за проектиране на бази данни, оптимизация на заявки и сигурност на данните. Участниците усвояват знания и умения, необходими за създаване, управление и използване на бази данни в различни софтуерни проекти.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), "DB Lecture" },
                    { 4, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лекцията по бизнес представя основни принципи на бизнеса, включително стратегическо планиране, мениджмънт, маркетинг, финанси и операции. Участниците разбират как да анализират пазара, да разработят бизнес стратегии, да управляват финансовите ресурси и да създадат успешни продукти или услуги. Лекцията помага на студентите и професионалистите да разберат основите на бизнеса и да приложат тези знания в практиката.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), "Business Lecture" },
                    { 5, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лекцията по дизайн представя ключови концепции и методи за създаване на визуално привлекателни и функционални продукти или интерфейси. Тя обхваща теми като цветови теории, композиция, типография, UX (потребителски опит) и UI (потребителски интерфейс) дизайн. Участниците усвояват практически умения и инструменти за проектиране, които им помагат да създадат усъвършенствани и интуитивни продукти за крайните потребители.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), "Design Lecture" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CourseId", "Description", "InstructorId", "LectureId", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP), включително инкапсулация, наследяване и полиморфизъм.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 1, "Принципи на Обектно-ориентираното програмиране" },
                    { 2, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Този материал представя теми по програмирането на C#, включително работа с LINQ, асинхронно програмиране и напреднали структури на данни.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 2, "Програмиране на C#" },
                    { 3, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Този материал представя основни концепции и технологии в областта на базите данни, включително релационни бази данни, SQL заявки и моделиране на данни.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 3, "Основи на базите данни" },
                    { 4, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Този материал представя основни концепции в областта на бизнеса, включително управление на проекти, маркетинг и стратегическо планиране.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 4, "Основи на бизнеса" },
                    { 5, new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), "Този материал представя основни принципи на дизайна, включително цветове, композиция и типография.", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 5, "Дизайн принципи" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InstructorId",
                table: "Materials",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_LectureId",
                table: "Materials",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Courses_CourseId",
                table: "Materials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Instructors_InstructorId",
                table: "Materials",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Lectures_LectureId",
                table: "Materials",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
