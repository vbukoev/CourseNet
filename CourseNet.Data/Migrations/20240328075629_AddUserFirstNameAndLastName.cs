using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class AddUserFirstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test",
                comment: "Student First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov",
                comment: "Student Last Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Student Identifier"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Student Email"),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Student First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Student Last Name"),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Student Phone Number"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                },
                comment: "Student Table");

            migrationBuilder.CreateIndex(
                name: "IX_User_CourseId",
                table: "User",
                column: "CourseId");
        }
    }
}
