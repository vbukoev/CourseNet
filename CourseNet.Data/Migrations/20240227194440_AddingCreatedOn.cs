using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class AddingCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 19, 44, 39, 727, DateTimeKind.Utc).AddTicks(704),
                comment: "Course Creation Date");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("3b51ea41-f01f-44f2-bf1c-24e89a42421e"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("7e13d79b-5979-4a87-ba36-bd53ce5998e0"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("8edeba69-5a42-4e00-b1a7-de2f6e8c59e9"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3b51ea41-f01f-44f2-bf1c-24e89a42421e"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7e13d79b-5979-4a87-ba36-bd53ce5998e0"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8edeba69-5a42-4e00-b1a7-de2f6e8c59e9"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 24, 11, 21, 29, 627, DateTimeKind.Utc).AddTicks(7762),
                comment: "Course Start Date");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("a9aba473-b04d-4a68-b4fb-27836fd1cb71"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("c718b08c-ebdc-4708-bbe1-60dc8dfe4c0e"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "StartDate", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("e6444e96-ce3d-4e50-a3e7-bb8bd0410507"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Design Advanced " });
        }
    }
}
