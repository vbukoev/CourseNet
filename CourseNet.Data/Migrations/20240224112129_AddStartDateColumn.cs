using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class AddStartDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("44dec55c-24ca-4e43-a572-f707223e8801"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a6662e97-ea9f-4177-8b5a-2bf7d64ccfae"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("cb3c7914-a6a8-4bf2-8bb0-207c6ac1c2f1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 24, 11, 21, 29, 627, DateTimeKind.Utc).AddTicks(7762),
                comment: "Course Start Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Course Start Date");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("a9aba473-b04d-4a68-b4fb-27836fd1cb71"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("c718b08c-ebdc-4708-bbe1-60dc8dfe4c0e"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("e6444e96-ce3d-4e50-a3e7-bb8bd0410507"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a9aba473-b04d-4a68-b4fb-27836fd1cb71"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("c718b08c-ebdc-4708-bbe1-60dc8dfe4c0e"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e6444e96-ce3d-4e50-a3e7-bb8bd0410507"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                comment: "Course Start Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 24, 11, 21, 29, 627, DateTimeKind.Utc).AddTicks(7762),
                oldComment: "Course Start Date");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("44dec55c-24ca-4e43-a572-f707223e8801"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("a6662e97-ea9f-4177-8b5a-2bf7d64ccfae"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("cb3c7914-a6a8-4bf2-8bb0-207c6ac1c2f1"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Design Advanced " });
        }
    }
}
