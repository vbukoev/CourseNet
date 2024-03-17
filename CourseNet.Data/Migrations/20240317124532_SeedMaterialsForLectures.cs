using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedMaterialsForLectures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
