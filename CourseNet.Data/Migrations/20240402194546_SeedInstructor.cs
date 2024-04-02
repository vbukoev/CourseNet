using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("c80e6eb5-a73a-449d-9a4c-2284b8ddbbea"), "futureInstructor@instructors.com", "Future", "Instructor", "+359123456789", new Guid("120206e2-d1e9-4b04-bf2c-943fe9a1793d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("c80e6eb5-a73a-449d-9a4c-2284b8ddbbea"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("120206e2-d1e9-4b04-bf2c-943fe9a1793d"), 0, "5e250d88-7bff-4450-a760-85b4979b9fe6", "futureInstructor@instructors.com", false, "Future", "Instructor", false, null, "FUTUREINSTRUCTOR@INSTRUCTORS.COM", "FUTUREINSTRUCTOR@INSTRUCTORS.COM", "AQAAAAEAACcQAAAAEDLla1IkEe9tqOl+WlDP8cGFOThn8a9ajXn87VBR0GYLkK57J3/+8HD3x7y/U5+RMw==", null, false, "6ac9b051-54d9-486f-acd0-42b99c639fb5", false, "futureInstructor@instructors.com" });
        }
    }
}
