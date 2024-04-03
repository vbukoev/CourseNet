using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class AddingSecurityStampToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d01ec426-abe0-49fe-94f2-792c342147b4"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a00c367b-d2bd-497c-ab97-c5e72200f9d7"), 0, "e02da19c-3813-48f9-923a-075a34560c68", "test@students.com", false, "Student", "Studentov", false, null, "TEST@STUDENTS.COM", "TEST@STUDENTS.COM", "AQAAAAEAACcQAAAAEAXbQvnuqUBWNEWR6t2GnCY5Q7v4tB3xsed7uN3m4UIzzg318XwfemAeGnE4622Dtg==", null, false, "07c7b5f3-ec63-41f5-8df3-e8dd68a62374", false, "test@students.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a00c367b-d2bd-497c-ab97-c5e72200f9d7"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d01ec426-abe0-49fe-94f2-792c342147b4"), 0, "e990116b-f46d-4474-bc92-40448f529f3f", "test@students.com", false, "Student", "Studentov", false, null, "TEST@STUDENTS.COM", "TEST@STUDENTS.COM", "AQAAAAEAACcQAAAAEKrzLMw6fX9MoSu2fp3rt6NIauhBo+BRMNQ3SkgIXJgK1kSDhfUq4TS+Y8HH5S2B8A==", null, false, null, false, "test@students.com" });
        }
    }
}
