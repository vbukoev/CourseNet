using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedFutureInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e0639283-6c7f-4b82-a871-e5df2b666255"), 0, "cda554be-26c0-4feb-bf4e-5adcbaad15c7", "futureInstructor@instructors.com", false, "Future", "Instructor", false, null, "FUTUREINSTRUCTORS@INSTRUCTORS.COM", "FUTUREINSTRUCTORS@INSTRUCTORS.COM", "AQAAAAEAACcQAAAAEJrL9mtELuRWibB9n88tG6f1tEiURsUqWu20Rt9pvNNbvhiEXE8uz89gZrHvLKBwGg==", null, false, "4d9571d8-ca32-48bf-b2ee-80b86b2c6e10", false, "futureInstructor@instructors.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f64609c-1ab3-4d7a-9cb9-b05a385e9a10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0639283-6c7f-4b82-a871-e5df2b666255"));

        }
    }
}
