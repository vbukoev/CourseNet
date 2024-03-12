using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class addingLectureMaterialReviewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Student Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                comment: "Category Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Lecture Identifier"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Lecture Title"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Lecture Description"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Lecture Date"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Course Identifier"),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Instructor Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Lecture Table");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Material Identifier"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Material Name"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Material Description"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Material Path"),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Instructor Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Material Table");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Student Identifier"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Student First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Student Last Name"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Student Email"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Student Phone Number"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                },
                comment: "Student Table");

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    EnrolledCoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => new { x.EnrolledCoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseUser_Courses_EnrolledCoursesId",
                        column: x => x.EnrolledCoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Review Identifier"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Review Rating"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Review Comment"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Review Date"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Course Identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Student Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Students_UserId",
                        column: x => x.UserId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Review Table");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"), 2, "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("407f3f88-7ae6-4941-9a42-5e29b457ce5e"), 3, "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("a1acfdbd-1ba2-48d5-b1f3-e43f4756172e"), 1, "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_StudentsId",
                table: "CourseUser",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InstructorId",
                table: "Materials",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseId",
                table: "Reviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3ce6e9d9-287a-4aa4-8c61-58fabc462dce"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("407f3f88-7ae6-4941-9a42-5e29b457ce5e"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a1acfdbd-1ba2-48d5-b1f3-e43f4756172e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Student Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Category Identifier");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("5e222db6-0282-4a36-9840-1c69c143eeee"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете как да управлявате бизнеса си", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 3, null, "Business Management" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("b9ca0248-b139-4ca9-94a3-5f864906c988"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете напреднали техники на дизайна", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 2, null, "Design Advanced " });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Difficulty", "EndDate", "ImagePath", "InstructorId", "Price", "Status", "StudentId", "Title" },
                values: new object[] { new Guid("c2f1d38a-8a73-4cda-91c5-c50f8bccb344"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Научете основите на C# език за програмиране", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new Guid("2e96bdce-d188-4e4d-9f37-addfe53f8fa7"), 0m, 0, new Guid("f2dedb39-40b0-4042-cbe4-08dc3524bc5d"), "C# Fundamentals" });
        }
    }
}
