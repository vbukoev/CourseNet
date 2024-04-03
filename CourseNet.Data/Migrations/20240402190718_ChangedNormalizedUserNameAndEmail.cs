using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class ChangedNormalizedUserNameAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("556ef159-d702-4b2e-9829-96adcf643df3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("600b8960-0a29-4061-a53a-50331e6aa0cf"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d01ec426-abe0-49fe-94f2-792c342147b4"), 0, "e990116b-f46d-4474-bc92-40448f529f3f", "test@students.com", false, "Student", "Studentov", false, null, "TEST@STUDENTS.COM", "TEST@STUDENTS.COM", "AQAAAAEAACcQAAAAEKrzLMw6fX9MoSu2fp3rt6NIauhBo+BRMNQ3SkgIXJgK1kSDhfUq4TS+Y8HH5S2B8A==", null, false, null, false, "test@students.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d01ec426-abe0-49fe-94f2-792c342147b4"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("556ef159-d702-4b2e-9829-96adcf643df3"), 0, "2b5598a7-19e0-43bd-a121-71577368aca4", "test@students.com", false, "Student", "Studentov", false, null, "test@students.com", "TEST", "AQAAAAEAACcQAAAAEGtnSPhUNvh2PgES0KAx6g1y6tYihr3N1RdXYMeQTzeGh99onWkyOdBNDviBeMzVyA==", null, false, null, false, "test@students.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("600b8960-0a29-4061-a53a-50331e6aa0cf"), 0, "39d11e92-c450-46a2-b325-fe01d0061d24", "admin@admins.com", false, "Admin", "Adminov", false, null, "admin@admins.com", "ADMIN", "AQAAAAEAACcQAAAAEFHo92X2kfkHaGNMHgv5UrG+AGh9aqFxmO7A8pzOrSCBVXSF9tRsCVYaxFlWMJWQvQ==", null, false, null, false, "admin@admins.com" });
        }
    }
}
