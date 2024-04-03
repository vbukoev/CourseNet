using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Last Name of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "Testov",
                oldComment: "Student Last Name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "First Name of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "Test",
                oldComment: "Student First Name");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("76d3d210-1cd7-4671-b5f2-fe2d852b2393"), 0, "7bcef810-487d-4b2f-b20d-558f0a9e8aec", "admin@admins.com", false, "Admin", "Adminov", false, null, "admin@admins.com", "ADMIN", "AQAAAAEAACcQAAAAEHivRs38wnNAt5A2qRQvoiQNSGtVEZDaMekQYbQf1LF1BZW0zVo45n8skm9aHltKVQ==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cc82f169-0e9b-46b5-b255-b436e757539b"), 0, "c60600ec-2d16-45f0-89e1-c9056661c7a5", "test@students.com", false, "Student", "Studentov", false, null, "test@students.com", "TEST", "AQAAAAEAACcQAAAAEP+speOgxR1w+DjtQ3Kn+K55nH6g0xPQazClJ2yJMUsirUaHK+NC7Rfv1IJLjMj9eA==", null, false, null, false, "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d3d210-1cd7-4671-b5f2-fe2d852b2393"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc82f169-0e9b-46b5-b255-b436e757539b"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov",
                comment: "Student Last Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Last Name of the User");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test",
                comment: "Student First Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "First Name of the User");
        }
    }
}
