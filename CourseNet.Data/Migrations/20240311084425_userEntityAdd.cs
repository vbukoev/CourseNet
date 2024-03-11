using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class userEntityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("26847e9d-afcf-444d-b632-85032cd4e153"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3170bfd9-a623-434c-9159-3ab77189e714"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("85b46a3b-8fb7-4b56-a6f9-472d465542a4"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("5e222db6-0282-4a36-9840-1c69c143eeee"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("b9ca0248-b139-4ca9-94a3-5f864906c988"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("c2f1d38a-8a73-4cda-91c5-c50f8bccb344"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5e222db6-0282-4a36-9840-1c69c143eeee"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("b9ca0248-b139-4ca9-94a3-5f864906c988"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c2f1d38a-8a73-4cda-91c5-c50f8bccb344"));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("26847e9d-afcf-444d-b632-85032cd4e153"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("3170bfd9-a623-434c-9159-3ab77189e714"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("85b46a3b-8fb7-4b56-a6f9-472d465542a4"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });
        }
    }
}
