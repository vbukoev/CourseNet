using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class ChangedFutureInstructorNormalizedUsernameAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f64609c-1ab3-4d7a-9cb9-b05a385e9a10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0639283-6c7f-4b82-a871-e5df2b666255"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("120206e2-d1e9-4b04-bf2c-943fe9a1793d"), 0, "5e250d88-7bff-4450-a760-85b4979b9fe6", "futureInstructor@instructors.com", false, "Future", "Instructor", false, null, "FUTUREINSTRUCTOR@INSTRUCTORS.COM", "FUTUREINSTRUCTOR@INSTRUCTORS.COM", "AQAAAAEAACcQAAAAEDLla1IkEe9tqOl+WlDP8cGFOThn8a9ajXn87VBR0GYLkK57J3/+8HD3x7y/U5+RMw==", null, false, "6ac9b051-54d9-486f-acd0-42b99c639fb5", false, "futureInstructor@instructors.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("120206e2-d1e9-4b04-bf2c-943fe9a1793d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8f64609c-1ab3-4d7a-9cb9-b05a385e9a10"), 0, "0ef27753-3336-46af-aac1-01bbfdfb5c5c", "test@students.com", false, "Student", "Studentov", false, null, "TEST@STUDENTS.COM", "TEST@STUDENTS.COM", "AQAAAAEAACcQAAAAEKaVcLSnwq3vkgbEYXEY88d7XY7GgJ5ljc00YkrPGl6iKQKp4r/k5+8nXQVbg3I8Hg==", null, false, "93f7f4b2-e69b-4094-8944-754865791a26", false, "test@students.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e0639283-6c7f-4b82-a871-e5df2b666255"), 0, "cda554be-26c0-4feb-bf4e-5adcbaad15c7", "futureInstructor@instructors.com", false, "Future", "Instructor", false, null, "FUTUREINSTRUCTORS@INSTRUCTORS.COM", "FUTUREINSTRUCTORS@INSTRUCTORS.COM", "AQAAAAEAACcQAAAAEJrL9mtELuRWibB9n88tG6f1tEiURsUqWu20Rt9pvNNbvhiEXE8uz89gZrHvLKBwGg==", null, false, "4d9571d8-ca32-48bf-b2ee-80b86b2c6e10", false, "futureInstructor@instructors.com" });
        }
    }
}
